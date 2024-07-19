using GoodReadersClone.Infrastructure.Utils;

namespace GoodReadersClone.Application.Features.Users.Handlers;

public class CreateReaderCommandHandler(
    UserManager<ApplicationUser> _userManager,
    ILogger<CreateReaderCommandHandler> _logger,
    IMapper _mapper) : IRequestHandler<CreateReaderCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateReaderCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request.Request);


        if (request.Request.ProfilePicture is not null)
        {
            if (!FileManager.IsValidFormat(request.Request.ProfilePicture))
                return new ApiResponse { Message = $"Invalid File Format, Valid Formats:({FileManager.ValidImageFormats})" };

            if (!FileManager.IsValidImageSize(request.Request.ProfilePicture))
                return new ApiResponse { Message = $"Invalid File Size, Maximum file size: ({FileManager.MaxImageSizeInMB}MB)" };

            // user.ProfilePectureURL = FileManager.UpsertImage(request.Request.ProfilePicture, FileManager.ProfilePicturesPath);
        }

        var result = await _userManager.CreateAsync(user, request.Request.Password);

        if (!result.Succeeded)
            return new ApiResponse { Message = "Error Occured" };

        await _userManager.AddToRoleAsync(user, Roles.READER);

        return new ApiResponse
        {
            Success = true,
            Message = "User created successfully",
            Data = new { user.Id }
        };
    }
}
