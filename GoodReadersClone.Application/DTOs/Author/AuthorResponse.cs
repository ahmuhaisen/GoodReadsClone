namespace GoodReadsClone.Application.DTOs.Author;
public class AuthorResponse
{
    public required string Id { get; set; }
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public int? NumberOfBooks { get; set; }

    public static AuthorResponse ConvertApplicationUserToUserResponse(Domain.Entities.Author author)
    {
        return new AuthorResponse
        {
            Id = author.Id,
            UserName = author.UserName!,
            FullName = $"{author.FirstName!} {author.LastName!}",
        };
    }
}
