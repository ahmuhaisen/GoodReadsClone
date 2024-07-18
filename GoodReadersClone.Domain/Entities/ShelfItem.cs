using GoodReadersClone.Domain.Enums;

namespace GoodReadersClone.Domain.Entities;

public class ShelfItem : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public string ReaderId { get; set; }
    public ApplicationUser Reader { get; set; }

    public Shelf Shelf { get; set; }

    public DateTime? DateRead { get; set; }
}
