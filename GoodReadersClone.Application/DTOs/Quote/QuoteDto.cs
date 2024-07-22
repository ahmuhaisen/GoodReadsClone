using System.ComponentModel.DataAnnotations;
namespace GoodReadsClone.Application.DTOs.Quote;
public class QuoteDto
{
    [MaxLength(200)]
    public required string Body { get; set; }

    public string? UserId { get; set; } = string.Empty;

    public required int BookId { get; set; }
}
