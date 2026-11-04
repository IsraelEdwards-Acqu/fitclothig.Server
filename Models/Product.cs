namespace FITClothing.Shared.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal BasePrice { get; set; }

    public string SKU { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; } = true;

    public Guid CategoryId { get; set; }

    public Guid BrandId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Category? Category { get; set; }
    public string ThumbnailUrl { get; set; } = string.Empty;

    public string BrandName { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public int MinimumOrderQuantity { get; set; } = 1;

    public bool AllowSingleOrder { get; set; }

    public bool HasFrontDesign { get; set; } = true;

    public bool HasBackDesign { get; set; } = true;
    public Brand? Brand { get; set; }

    public ICollection<ProductImage> Images { get; set; }
    = new List<ProductImage>();

    public ICollection<ProductColor> Colors { get; set; }
        = new List<ProductColor>();

    public ICollection<ProductSize> Sizes { get; set; }
        = new List<ProductSize>();

}