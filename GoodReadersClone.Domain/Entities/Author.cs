﻿namespace GoodReadersClone.Domain.Entities;

public class Author : ApplicationUser
{
    public IList<Book> Books { get; set; }


    public ICollection<AuthorFollowing> Followers { get; set; } = [];
}
