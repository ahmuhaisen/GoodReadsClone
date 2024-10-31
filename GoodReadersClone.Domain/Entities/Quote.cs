using GoodReadsClone.Domain.Abstractions;

namespace GoodReadsClone.Domain.Entities;

public class Quote : IEntity
{
    public int Id { get; set; }
    public string Body { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; } 
}