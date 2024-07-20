namespace GoodReadersClone.Application.DTOs.AuthorFollowing;
public class FollowResponse
{
    public required string UserID { get; set; }
    public required string AuthorId { get; set; }
    public required string UserName { get; set; }
    public required string AuthorName { get; set; }
}
