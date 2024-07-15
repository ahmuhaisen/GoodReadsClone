using GoodReadersClone.Application.DTOs.User;
using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Application.Features.Users.Handlers;

public class CreateReaderCommandHandler(
    UserManager<ApplicationUser> _userManager,
    ILogger<CreateReaderCommandHandler> _logger,
    IMapper _mapper) : IRequestHandler<CreateReaderCommand, UserModel>
{
    public async Task<UserModel> Handle(CreateReaderCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Request is null)
            return new UserModel { Message = "Request can't be null" };

        var user = _mapper.Map<ApplicationUser>(request.Request);


        if (request.Request.ProfilePicture is not null)
        {
            if (!FileManager.IsValidFormat(request.Request.ProfilePicture))
                return new UserModel { Message = $"Invalid File Format, Valid Formats:({FileManager.ValidImageFormats})" };

            if (!FileManager.IsValidImageSize(request.Request.ProfilePicture))
                return new UserModel { Message = $"Invalid File Size, Maximum file size: ({FileManager.MaxImageSizeInMB}MB)" };

            // user.ProfilePectureURL = FileManager.UpsertImage(request.Request.ProfilePicture, FileManager.ProfilePicturesPath);
        }

        var result = await _userManager.CreateAsync(user, request.Request.Password);

        if (!result.Succeeded)
            return new UserModel { Message = result.Errors.FirstOrDefault()?.Description };

        await _userManager.AddToRoleAsync(user, Roles.READER);

        return new UserModel 
        {
            Message = "User created successfully",
            Id = user.Id,
            Roles = (await _userManager.GetRolesAsync(user)).ToArray()
        };
    }
}
