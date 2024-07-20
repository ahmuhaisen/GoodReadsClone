using GoodReadersClone.Application.Features.Books.Commands;

namespace GoodReadersClone.Application.Features.Books.Handlers;

public class EditBookCommandHandler(
    IUnitOfWork _unitOfWork,
    IHttpContextAccessor _httpContextAccessor
    )
    : IRequestHandler<EditBookCommand, ApiResponse>
{
    public async Task<ApiResponse> Handle(EditBookCommand request, CancellationToken cancellationToken)
    {
        var bookToUpdate = await _unitOfWork.BookRepository.GetAsync(x => x.Id == request.BookId, new[] { "Genres" });

        if (bookToUpdate is null)
            return new ApiResponse { Message = $"Book with Id `{request.BookId}` Not Found" };

        var currentAuthorId = _httpContextAccessor.HttpContext.User.FindFirstValue("uid");

        if(bookToUpdate.AuthorId != currentAuthorId)
            return new ApiResponse { Message = $"You cann't edit this book" };


        if (bookToUpdate.Title != request.Request.Title
            && await _unitOfWork.BookRepository.IsExist(x => x.Title == request.Request.Title))
            return new ApiResponse { Message = "There exist a book with same title" };

        if (request.Request.FirstPublished > DateTime.Now)
            return new ApiResponse { Message = "Invalid FirstPublished Date" };

        if (!string.IsNullOrEmpty(request.Request.Title))
            bookToUpdate.Title = request.Request.Title;

        if (!string.IsNullOrEmpty(request.Request.Description))
            bookToUpdate.Description = request.Request.Description;

        if (request.Request.FirstPublished is not null)
            bookToUpdate.FirstPublished = (DateTime)request.Request.FirstPublished;


        if (request.Request.Cover is not null)
        {
            //Delete the Old Cover
            //Save the New one
            bookToUpdate.CoverURL = $"{FileManager.BooksCoversPath}\\{Guid.NewGuid().ToString()}.jpg";
        }

        if (!string.IsNullOrEmpty(request.Request.Genres))
        {
            bookToUpdate.Genres.Clear();
            var genresToAttach = request.Request.Genres.Split(',').Select(x => x.Trim());
            foreach (var genreName in genresToAttach)
            {
                var genre = await _unitOfWork.GenreRepository.GetAsync(x => x.Name == genreName);
                if (genre is not null)
                    bookToUpdate.Genres.Add(genre);
            }
        }

        _unitOfWork.BookRepository.Update(bookToUpdate);
        var result = _unitOfWork.Save();

        if (result == 0)
            return new ApiResponse { Message = "Failed to update the book" };

        return new ApiResponse
        {
            Success = true,
            Data = bookToUpdate.Id
        };
    }
}
