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
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<HeroSlide> HeroSlides => Set<HeroSlide>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<CategorySection>
    CategorySections => Set<CategorySection>();
    public DbSet<CategoryHeroBanner>
    CategoryHeroBanners => Set<CategoryHeroBanner>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<MenuItem>
    MenuItems => Set<MenuItem>();
    public DbSet<WishlistItem>
    WishlistItems => Set<WishlistItem>();
    public DbSet<Order> Orders
    => Set<Order>();
    public DbSet<OrderItem> OrderItems
        => Set<OrderItem>();
    public DbSet<OrderStatusHistory>
    OrderStatusHistories
    => Set<OrderStatusHistory>();
    public ICollection<OrderStatusHistory>
    StatusHistory
    { get; set; }
    = new List<OrderStatusHistory>();
    public DbSet<QuoteRequest>
    QuoteRequests => Set<QuoteRequest>();
    public DbSet<QuoteStatusHistory>
    QuoteStatusHistories
    => Set<QuoteStatusHistory>();
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
        modelBuilder.Entity<Order>()
    .HasMany(x => x.Items)
    .WithOne(x => x.Order)
    .HasForeignKey(x => x.OrderId);
    }

}