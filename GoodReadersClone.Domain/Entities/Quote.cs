using GoodReadersClone.Domain.Abstractions;

namespace GoodReadersClone.Domain.Entities;

public class Quote : IEntity
{
    public int Id { get; set; }
    public string Body { get; set; } 

    public string UserId{ get; set; }
    public ApplicationUser User{ get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}