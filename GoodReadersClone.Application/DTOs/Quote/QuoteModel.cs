using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoodReadersClone.Application.DTOs.Quote;
public class QuoteModel
{
    [MaxLength(200)]
    public required string Body { get; set; }

    [JsonIgnore]
    public string? UserId { get; set; }

    public required int BookId { get; set; }
}
