using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.Quote;
public class QuoteModel
{
    [MaxLength(200)]
    public required string Body { get; set; }

    public required string UserId { get; set; }

    public required int BookId { get; set; }
}
