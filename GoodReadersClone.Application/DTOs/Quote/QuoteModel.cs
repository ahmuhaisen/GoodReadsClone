using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoodReadersClone.Application.DTOs.Quote;
public class QuoteModel
{
    [MaxLength(200)]
    public required string Body { get; set; }

    [JsonIgnore]
    public string? UserId { get; set; } = string.Empty;

    public required int BookId { get; set; }
}
