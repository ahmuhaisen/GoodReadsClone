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
}
