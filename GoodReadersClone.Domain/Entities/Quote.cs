using GoodReadersClone.Domain.Abstractions;

namespace GoodReadersClone.Domain.Entities;

public class Quote : IEntity
{
    public int Id { get; set; }
    public string Body { get; set; } = string.Empty;

    public string UserId{ get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = new();

    public int BookId { get; set; }
    public Book Book { get; set; } = new();
}