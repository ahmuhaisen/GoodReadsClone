﻿using GoodReadersClone.Domain.Abstractions;

namespace GoodReadersClone.Domain.Entities;

public class Genre : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Book> Books { get; set; } = [];
}
