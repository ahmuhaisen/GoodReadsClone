using GoodReadsClone.Application.DTOs;

namespace GoodReadsClone.Application.Features.Books.Queries;
public record GetAllBooksQuery(string SearchTerm, int PageIndex, int PageSize) : IRequest<ApiResponse>;
