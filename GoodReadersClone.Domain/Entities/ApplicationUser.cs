using Microsoft.AspNetCore.Identity;

namespace GoodReadersClone.Domain.Entities;


public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? ProfilePectureURL { get; set; }
    public DateTime JoindAt { get; set; }
}
