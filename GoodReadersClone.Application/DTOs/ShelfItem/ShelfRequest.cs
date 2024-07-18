using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.ShelfItem;
public class ShelfRequest
{
    public int BookId { get; set; }

    public string ReaderId { get; set; }

    [Range(1, 3)]
    public int Shelf { get; set; }
}
