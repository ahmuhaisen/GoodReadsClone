namespace GoodReadersClone.Domain.Entities;

public class AuthorFollowing
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public string AuthorId { get; set; }
    public Author Author { get; set; }
}
