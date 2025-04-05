using System.IO.Compression;
using BooksProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksProj.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Purchase>()
            .HasMany(p => p.Books)
            .WithOne()
            .HasForeignKey(b => b.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade) 
            .IsRequired(false);

        // seed the roles, add more here if needed
        List<IdentityRole> roles = 
        [
            new IdentityRole
            {
                Id = "User",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
    }
}