namespace GoodReadersClone.Domain.Entities;


public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverURL { get; set; }
    public string ISBN { get; set; }
    public DateTime FirstPublished { get; set; }


    public string AuthorId { get; set; }
    public Author Author { get; set; }


    public List<Genre> Genres { get; set; }
}
