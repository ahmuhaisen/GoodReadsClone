using GoodReadsClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadsClone.Infrastructure.DataAccess.Data.Congifurations;

public class ReviewConfig : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => new { x.ReaderId, x.BookId });

        builder.Property(x => x.Text).HasMaxLength(500);

        builder.HasOne(r => r.Reader)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.ReaderId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(r => r.Book)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
