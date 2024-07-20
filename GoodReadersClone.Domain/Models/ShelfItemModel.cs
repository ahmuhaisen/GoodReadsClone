public class ShelfItemModel
{
    public string? BookCoverUrl { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string BookAuthorName { get; set; } = string.Empty;
    public double BookAvgRating { get; set; }
    public int? Rating { get; set; }
    public string Shelf { get; set; } = string.Empty;
    public string? Review { get; set; }
    public string? DateRead { get; set; }
}
