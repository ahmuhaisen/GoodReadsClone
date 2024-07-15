namespace GoodReadersClone.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public IList<Book> Books { get; set; }
}
