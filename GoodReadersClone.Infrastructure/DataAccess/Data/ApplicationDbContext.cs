using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;
using GoodReadersClone.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoodReadersClone.Infrastructure.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfig).Assembly);

        modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

    }
}
