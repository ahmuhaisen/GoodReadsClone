using GoodReadersClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;

public class ShelfItemConfig : IEntityTypeConfiguration<ShelfItem>
{
    public void Configure(EntityTypeBuilder<ShelfItem> builder)
    {
        builder.ToTable($"{nameof(ShelfItem)}s");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

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
