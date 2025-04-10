﻿using GoodReadsClone.Domain.Abstractions;
using GoodReadsClone.Domain.Enums;

namespace GoodReadsClone.Domain.Entities;

public class ShelfItem : IEntity
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; } 

    public string ReaderId { get; set; } = string.Empty;
    public ApplicationUser? Reader { get; set; }

    public Shelf Shelf { get; set; }

    public DateTime? DateRead { get; set; }
}
