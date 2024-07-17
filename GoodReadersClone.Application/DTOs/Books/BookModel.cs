namespace GoodReadersClone.Application.DTOs.Books;
public class BookModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string CoverURL { get; set; }
    public string ISBN { get; set; }
    public DateTime FirstPublished { get; set; }

    public string? Genres { get; set; }

    public static BookModel ConvertBookToBookModel(Book book)
    {
        var genres = book.Genres is null ? null : string.Join(", ", book.Genres.Select(x => x.Name));
        var author = book.Author is null ? book.AuthorId.ToString() : $"{book.Author.FirstName} {book.Author.LastName}";
        
        return new BookModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = author,
            Description = book.Description,
            Genres = genres,
            FirstPublished = book.FirstPublished,
            ISBN = book.ISBN,
            CoverURL = book.CoverURL
        };
    }
}
