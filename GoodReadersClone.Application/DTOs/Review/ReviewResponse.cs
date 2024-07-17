namespace GoodReadersClone.Application.DTOs.Review;
public class ReviewResponse
{
    public string? Text { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ReaderName { get; set; } = null;
    public string? BookName { get; set; } = null;
}
