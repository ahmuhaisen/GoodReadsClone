using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Application.Features.Books.Queries;
public record GetAllBooksQuery(int PageIndex, int PageSize) : IRequest<ApiResponse>;
