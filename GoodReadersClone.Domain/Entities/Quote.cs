namespace GoodReadersClone.Domain.Entities;

public class Quote : BaseEntity
{
    public string Body { get; set; }

    public string UserId{ get; set; }
    public ApplicationUser User{ get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}