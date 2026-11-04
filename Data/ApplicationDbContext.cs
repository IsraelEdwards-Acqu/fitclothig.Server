using FITClothing.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Brand> Brands => Set<Brand>();

    public DbSet<Promotion> Promotions => Set<Promotion>();
    public DbSet<Design> Designs => Set<Design>();
    public DbSet<ProductColor> ProductColors => Set<ProductColor>();

    public DbSet<ProductSize> ProductSizes => Set<ProductSize>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<HeroSlide> HeroSlides => Set<HeroSlide>();
    public DbSet<Review> Reviews => Set<Review>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Brand>()
            .HasMany(b => b.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId);
    }

}