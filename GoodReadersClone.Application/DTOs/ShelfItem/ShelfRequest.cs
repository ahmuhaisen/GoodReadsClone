using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoodReadersClone.Application.DTOs.ShelfItem;


public class ShelfRequest
{
    public required int BookId { get; set; }

    [JsonIgnore]
    public string? ReaderId { get; set; }

    [Range(1, 3)]
    public int Shelf { get; set; }
}
