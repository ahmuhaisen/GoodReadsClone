using GoodReadersClone.Domain.Abstractions;
using GoodReadersClone.Domain.Enums;

namespace GoodReadersClone.Domain.Entities;

public class ShelfItem : IEntity
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = new();

    public string ReaderId { get; set; } = string.Empty;
    public ApplicationUser Reader { get; set; } = new();

    public Shelf Shelf { get; set; }

    public DateTime? DateRead { get; set; }
}
