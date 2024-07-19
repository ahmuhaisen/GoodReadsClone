using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Application.Services;

public class AuthService(
    IOptions<JwtOptions> _jwtOptions,
    UserManager<ApplicationUser> _userManager,
    RoleManager<IdentityRole> _roleManager)
    : IAuthService
{
    public async Task<AuthModel> RegisterAsync(UserRegisterRequest model, string role)
    {
        if (await _userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthModel { Message = "Email is already registered" };

        if (await _userManager.FindByNameAsync(model.UserName) is not null)
            return new AuthModel { Message = "Username is already registered" };

        var user = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Discrimintator = role.Equals(Roles.READER) ? "ApplicationUser" : "Author"
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            var errors = string.Empty;
            errors = string.Join(',', result.Errors.Select(e => e.Description));
            return new AuthModel { Message = errors };
        }

        var refreshToken = GenerateRefreshToken();
        user.RefreshTokens?.Add(refreshToken);
        await _userManager.AddToRoleAsync(user, role);

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthModel
        {
            Username = user.UserName,
            Email = user.Email,
            //ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = new List<string> { role },
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiration = refreshToken.ExpiresOn
        };
    }

    public async Task<AuthModel> GetTokenAsync(TokenRequest request)
    {
        var authModel = new AuthModel();

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            authModel.Message = "Email or Password is incorrect";
            return authModel;
        }


        var jwtSecurityToken = await CreateJwtToken(user);
        var roles = await _userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.Email = user.Email!;
        authModel.Username = user.UserName!;
        authModel.Roles = roles.ToList();
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        //authModel.ExpiresOn = jwtSecurityToken.ValidTo;

        if (user.RefreshTokens.Any(t => t.IsActive))
        {
            var activerRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
            authModel.RefreshToken = activerRefreshToken.Token;
            authModel.RefreshTokenExpiration = activerRefreshToken.ExpiresOn;
        }
        else
        {
            var refreshToken = GenerateRefreshToken();
            authModel.RefreshToken = refreshToken.Token;
            authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;

            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);
        }

        return authModel;
    }

    public async Task<string> AddRoleAsync(AddRoleRequest model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);

        if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
            return "Invalid user Id or Role";

        if (await _userManager.IsInRoleAsync(user, model.Role))
            return "User is already assigned to this role";

        var result = await _userManager.AddToRoleAsync(user, model.Role);

        return result.Succeeded ? string.Empty : "Something went wrong";
    }

    public async Task<AuthModel> RefreshTokenAsync(string token)
    {
        var authModel = new AuthModel();

        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

        if (user is null)
        {
            //authModel.IsAuthenticated by default equals false;
            authModel.Message = "Invalid token";
            return authModel;
        }

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

        if (!refreshToken.IsActive)
        {
            authModel.Message = "Inactive token";
            return authModel;
        }

        refreshToken.RevokedOn = DateTime.UtcNow;

        var newRefreshToken = GenerateRefreshToken();

        user.RefreshTokens.Add(newRefreshToken);
        await _userManager.UpdateAsync(user);

        var jwtToken = await CreateJwtToken(user);

        authModel.IsAuthenticated = true;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        authModel.Email = user.Email;
        authModel.Username = user.UserName;
        authModel.Roles = _userManager.GetRolesAsync(user).Result.ToList();

        authModel.RefreshToken = newRefreshToken.Token;
        authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

        return authModel;
    }

    public async Task<bool> RevokeTokenAsync(string token)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

        if (user is null)
            return false;

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

        if (!refreshToken.IsActive)
            return false;

        refreshToken.RevokedOn = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);

        return true;
    }



    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in userRoles)
            roleClaims.Add(new Claim(ClaimTypes.Role, role));

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);


        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SigningKey!));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtOptions.Value.Issuer,
            audience: _jwtOptions.Value.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOptions.Value.DurationInMinuets),
            signingCredentials: signingCredentials
            );

        return jwtSecurityToken;
    }

    private RefreshToken GenerateRefreshToken()
    {
        var reandomNumber = new byte[32];

        using var generator = new RNGCryptoServiceProvider();

        generator.GetBytes(reandomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(reandomNumber),
            ExpiresOn = DateTime.UtcNow.AddDays(10),
            CreatedOn = DateTime.UtcNow
        };
    }
}

