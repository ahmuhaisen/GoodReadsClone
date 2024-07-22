using Microsoft.AspNetCore.Identity;

namespace GoodReadsClone.Domain.Entities;


public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfilePectureURL { get; set; }
    public DateTime JoindAt { get; set; }

    public string? Discrimintator { get; set; }


    public ICollection<Quote> Quotes { get; set; } = [];

    public ICollection<AuthorFollowing> AuthorFollowings { get; set; } = [];

    public ICollection<Review> Reviews { get; set; } = [];

    public ICollection<ShelfItem> ShelfItems { get; set; } = [];


    public ICollection<RefreshToken>? RefreshTokens { get; set; } = [];
}
