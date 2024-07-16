namespace GoodReadersClone.Application.DTOs.Books;
public record GetAllBooksRequest(
    int PageIndex = 1,
    int PageSize = 10
);