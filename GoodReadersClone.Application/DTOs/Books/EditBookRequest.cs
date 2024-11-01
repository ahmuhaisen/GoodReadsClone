﻿using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Books;

public class EditBookRequest
{
    [MinLength(10)]
    public required string? Title { get; set; }

    [MinLength(10)]
    public required string? Description { get; set; }

    [DataType(DataType.Date)]
    public required DateTime? FirstPublished { get; set; }

    public required string? Genres { get; set; } //Genre Names separated by a comma

    public IFormFile? Cover { get; set; }
}
