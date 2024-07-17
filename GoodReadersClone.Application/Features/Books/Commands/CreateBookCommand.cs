using GoodReadersClone.Application.DTOs.Books;

namespace GoodReadersClone.Application.Features.Books.Commands;
public record CreateBookCommand(CreateBookRequest Request) : IRequest<ApiResponse>;
