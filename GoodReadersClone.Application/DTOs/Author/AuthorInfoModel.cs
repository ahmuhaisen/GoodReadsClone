namespace GoodReadersClone.Application.DTOs.Author;
public class AuthorInfoModel
{
    public string? Message { get; set; } = string.Empty;
    public string? Id { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public int? NumberOfBooks { get; set; }

    public string NoOfFollowers { get; set; } = "Soon!";
}
