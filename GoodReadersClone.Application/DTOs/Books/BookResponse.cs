namespace GoodReadersClone.Application.DTOs.Books;
public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CoverURL { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime FirstPublished { get; set; }

    public string? Genres { get; set; }

    public static BookResponse ConvertBookToBookModel(Book book)
    {
        var genres = book.Genres is null ? null : string.Join(", ", book.Genres.Select(x => x.Name));
        var author = book.Author is null ? book.AuthorId.ToString() : $"{book.Author.FirstName} {book.Author.LastName}";
        
        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = author,
            Description = book.Description!,
            Genres = genres,
            FirstPublished = book.FirstPublished,
            ISBN = book.ISBN,
            CoverURL = book.CoverURL
        };
    }
}
