using GoodReadersClone.Domain.Entities;
using GoodReadersClone.Infrastructure.DataAccess.Data.Congifurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorFollowing> AuthorFollowings { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ShelfItem> ShelfItems { get; set; }
    public DbSet<ShelfItemModel> ShelfItemModels { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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

        modelBuilder.Entity<ShelfItemModel>()
            .HasNoKey()
            .ToView(null);

        modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(GetShelfItems), new[] { typeof(string) })!);
    }

    [DbFunction("GetShelfItems", "dbo")]
    public IQueryable<ShelfItemModel> GetShelfItems(string readerId)
    {
        var readerIdParam = new SqlParameter("@ReaderId", readerId);
        return ShelfItemModels.FromSqlRaw("SELECT * FROM dbo.GetShelfItems(@ReaderId)", readerIdParam);
    }
}
