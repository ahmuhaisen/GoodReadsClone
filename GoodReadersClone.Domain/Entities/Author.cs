namespace GoodReadersClone.Domain.Entities;

public class Author : ApplicationUser
{
    public ICollection<Book> Books { get; set; } = [];

    public ICollection<AuthorFollowing> Followers { get; set; } = [];
}
