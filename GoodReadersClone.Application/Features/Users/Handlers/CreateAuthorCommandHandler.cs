using GoodReadersClone.Infrastructure.Helpers;

namespace GoodReadersClone.Application.Features.Users.Handlers;

public class CreateAuthorCommandHandler(
    UserManager<ApplicationUser> _userManager,
    ILogger<CreateAuthorCommandHandler> _logger,
    IMapper _mapper) : IRequestHandler<CreateAuthorCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
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

        user.Discrimintator = "Author";

        var result = await _userManager.CreateAsync(user, request.Request.Password);

        if (!result.Succeeded)
            return new ApiResponse { Message = "Error Occured" };

        await _userManager.AddToRoleAsync(user, Roles.AUTHOR);

        return new ApiResponse
        {
            Success = true,
            Message = "Author created successfully",
            Data = new { user.Id }
        };
    }
}