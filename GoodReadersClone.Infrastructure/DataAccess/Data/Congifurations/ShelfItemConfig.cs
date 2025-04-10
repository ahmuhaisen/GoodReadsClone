﻿using GoodReadsClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadsClone.Infrastructure.DataAccess.Data.Congifurations;

public class ShelfItemConfig : IEntityTypeConfiguration<ShelfItem>
{
    public void Configure(EntityTypeBuilder<ShelfItem> builder)
    {
        builder.HasOne(r => r.Reader)
           .WithMany(u => u.ShelfItems)
           .HasForeignKey(r => r.ReaderId)
           .OnDelete(DeleteBehavior.NoAction)
           .IsRequired();

        builder.HasOne(r => r.Book)
            .WithMany(u => u.ShelfItems)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
