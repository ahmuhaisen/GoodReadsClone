using GoodReadersClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;
public class QuoteConfig : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.Property(x => x.Body)
            .HasMaxLength(500);


        builder.HasOne(q => q.Book)
            .WithMany(b => b.Quotes)
            .HasForeignKey(q => q.BookId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
