using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.AuthorFollowing;
public class FollowRequest
{
    [MinLength(7)]
    public required string AuthorId { get; set; }

    [MinLength(7)]
    public string? ReaderId { get; set; } = string.Empty;
}
