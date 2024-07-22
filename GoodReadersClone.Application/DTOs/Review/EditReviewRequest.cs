using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Review;

public class EditReviewRequest
{
    [Range(0, 5)]
    public int Rating { get; set; }

    [MaxLength(200)]
    public string? Text { get; set; }
}
