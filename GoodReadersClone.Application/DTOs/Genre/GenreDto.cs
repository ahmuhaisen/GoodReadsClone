using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Genre;
public class GenreDto
{
    [MinLength(3)]
    public required string Name { get; set; }
}
