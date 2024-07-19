using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.AuthorFollowing;
public class FollowingRequest
{
    [MinLength(7)]
    public required string AuthorId { get; set; }
    [MinLength(7)]
    public string? ReaderId { get; set; }
}
