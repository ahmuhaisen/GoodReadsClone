﻿namespace GoodReadsClone.Domain.Entities;

public class AuthorFollowing
{
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser? ApplicationUser { get; set; }

    public string AuthorId { get; set; } = string.Empty;
    public Author? Author { get; set; }
}
