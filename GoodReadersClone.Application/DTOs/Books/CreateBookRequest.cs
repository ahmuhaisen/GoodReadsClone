using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoodReadersClone.Application.DTOs.Books;
public class CreateBookRequest
{
    [MinLength(10)]
    public required string Title { get; set; }

    [JsonIgnore]
    public string? AuthorId { get; set; }

    [MinLength(10)]
    public required string Description { get; set; }

    [MinLength(9)]
    public required string ISBN { get; set; }

    [DataType(DataType.Date)]
    public required DateTime FirstPublished { get; set; }

    public required string Genres { get; set; } //Genre Names separated by a comma

    public IFormFile? Cover { get; set; }
}
