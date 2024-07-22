using GoodReadsClone.Application.DTOs.Books;

namespace GoodReadsClone.Application.Features.Books.Commands;
public record CreateBookCommand(CreateBookRequest Request) : IRequest<ApiResponse>;
public record EditBookCommand(int BookId, EditBookRequest Request) : IRequest<ApiResponse>;
public record DeleteBookCommand(int BookId) : IRequest<ApiResponse>;
