using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Review;
public class CreateReviewRequest
{
    [Range(0, 5)]
    public int Rating { get; set; }

    [MaxLength(200)]
    public string? Text { get; set; }

    public string? ReaderId { get; set; }

    public required int BookId { get; set; }
}
