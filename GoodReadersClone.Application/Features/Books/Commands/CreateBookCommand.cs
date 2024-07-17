using GoodReadersClone.Application.DTOs.Books;

namespace GoodReadersClone.Application.Features.Books.Commands;
public record CreateBookCommand(CreateBookRequest Request) : IRequest<ApiResponse>;
public record EditBookCommand(int BookId, EditBookRequest Request) : IRequest<ApiResponse>;
public record DeleteBookCommand(int BookId) : IRequest<ApiResponse>;
