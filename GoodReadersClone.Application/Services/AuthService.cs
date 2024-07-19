using Microsoft.AspNetCore.Identity;

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

        await _userManager.AddToRoleAsync(user, role);

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthModel
        {
            Username = user.UserName,
            Email = user.Email,
            //ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = new List<string> { role },
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };
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
}

