using System.ComponentModel.DataAnnotations;

namespace GoodReadersClone.Application.DTOs.ShelfItem;


public class ShelfRequest
{
    public required int BookId { get; set; }

    public required string ReaderId { get; set; }

    [Range(1, 3)]
    public int Shelf { get; set; }
}
