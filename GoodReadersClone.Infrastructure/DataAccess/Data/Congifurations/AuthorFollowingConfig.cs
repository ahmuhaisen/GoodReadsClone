using GoodReadersClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;

public class AuthorFollowingConfig : IEntityTypeConfiguration<AuthorFollowing>
{
    public void Configure(EntityTypeBuilder<AuthorFollowing> builder)
    {
        builder.HasKey(af => new { af.ApplicationUserId, af.AuthorId });

        builder.HasOne(af => af.ApplicationUser)
            .WithMany(u => u.AuthorFollowings)
            .HasForeignKey(af => af.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(af => af.Author)
            .WithMany(a => a.Followers)
            .HasForeignKey(af => af.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
