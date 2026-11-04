namespace FITClothing.Shared.Models;

public class Brand
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string LogoUrl { get; set; } = string.Empty;

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; }
        = new List<Product>();
}