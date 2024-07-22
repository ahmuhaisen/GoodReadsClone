using GoodReadsClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadsClone.Infrastructure.DataAccess.Data.Congifurations;


public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(250).IsRequired(true);
    }
}



