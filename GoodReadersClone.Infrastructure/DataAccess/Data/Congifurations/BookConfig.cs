using GoodReadersClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;


public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable($"{nameof(Book)}s");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).HasMaxLength(250).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.CoverURL).IsRequired(true);
        builder.Property(x => x.ISBN).IsRequired(true);
        builder.Property(x => x.FirstPublished).IsRequired(true);

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .IsRequired();
    }
}



