using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.Review;
public class ReviewRequest
{
    [Range(0, 5)]
    public int Rating { get; set; }

    [MaxLength(200)]
    public string? Text { get; set; }

    public string? ReaderId { get; set; }

    public required int BookId { get; set; }
}
