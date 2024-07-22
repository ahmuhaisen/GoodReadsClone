using GoodReadsClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadsClone.Infrastructure.DataAccess.Data.Congifurations;
public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users", "security");

        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.JoindAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.ProfilePectureURL)
            .IsRequired(false);

        builder.HasDiscriminator(x => x.Discrimintator);
    }
}
