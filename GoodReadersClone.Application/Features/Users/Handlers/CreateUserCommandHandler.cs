namespace GoodReadersClone.Application.Features.Users.Handlers;

public class CreateUserCommandHandler(
    UserManager<ApplicationUser> _userManager,
    ILogger<CreateUserCommandHandler> _logger,
    IMapper _mapper) : IRequestHandler<CreateUserCommand, UsersModel>
{
    public async Task<UsersModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Request is null)
            return new UsersModel { Message = "Request can't be null" };

        var user = _mapper.Map<ApplicationUser>(request.Request);

        if (request.Request.ProfilePicture is not null)
        {
            if (!FileManager.IsValidFormat(request.Request.ProfilePicture))
                return new UsersModel { Message = $"Invalid File Format, Valid Formats:({FileManager.ValidImageFormats})" };

            if (!FileManager.IsValidImageSize(request.Request.ProfilePicture))
                return new UsersModel { Message = $"Invalid File Size, Maximum file size: ({FileManager.MaxImageSizeInMB}MB)" };

            // user.ProfilePectureURL = FileManager.UpsertImage(request.Request.ProfilePicture, FileManager.ProfilePicturesPath);
        }

        var result = await _userManager.CreateAsync(user, request.Request.Password);

        if (!result.Succeeded)
            return new UsersModel { Message = result.Errors.FirstOrDefault()?.Description };

        return new UsersModel { Message = "User created successfully", Id = user.Id, UserName = user.UserName };
    }
}
