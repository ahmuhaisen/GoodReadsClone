namespace GoodReadersClone.Domain.Entities;

public class Review
{
    public string? Text { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }

    public string ReaderId { get; set; }
    public ApplicationUser Reader { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}

