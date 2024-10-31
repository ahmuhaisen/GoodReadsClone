using GoodReadsClone.Domain.Abstractions;

namespace GoodReadsClone.Domain.Entities;


public class Book : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string CoverURL { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public DateTime FirstPublished { get; set; }


    public string AuthorId { get; set; } = string.Empty;
    public Author Author { get; set; } 


    public ICollection<Genre> Genres { get; set; } = [];

    public ICollection<Quote> Quotes { get; set; } = [];

    public ICollection<Review> Reviews { get; set; } = [];

    public ICollection<ShelfItem> ShelfItems { get; set; } = [];
}
