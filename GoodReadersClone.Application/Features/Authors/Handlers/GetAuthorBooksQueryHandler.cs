using GoodReadsClone.Application.DTOs;
using GoodReadsClone.Application.Features.Authors.Queries;
using GoodReadsClone.Infrastructure.DataAccess.Abstractions;

namespace GoodReadsClone.Application.Features.Authors.Handlers;

public class GetAuthorBooksQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAuthorBooksQuery, ApiResponse>
{
    public async Task<ApiResponse> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        var author = _unitOfWork.AuthorRepository.IsExist(x => x.Id == request.AuthorId);

        if (!_unitOfWork.AuthorRepository.IsExist(x => x.Id == request.AuthorId))
            return new ApiResponse { Message = "Author Not Found" };

        var authorBooks = await _unitOfWork.BookRepository.GetAllAsync(x => x.AuthorId == request.AuthorId);

        return new ApiResponse
        {
            Success = true,
            Data = authorBooks
        };
    }
}


