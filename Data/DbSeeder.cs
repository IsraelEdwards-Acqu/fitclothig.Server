using FITClothing.Shared.Models;

namespace FITClothing.API.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(
        ApplicationDbContext context)
    {
        if (context.Categories.Any())
            return;

        var tshirts = new Category
        {
            Id = Guid.NewGuid(),
            Name = "T-Shirts",
            Slug = "t-shirts",
            Description = "Custom T-Shirts"
        };

        var hoodies = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Hoodies",
            Slug = "hoodies",
            Description = "Custom Hoodies"
        };

        context.Categories.AddRange(
            tshirts,
            hoodies);

        var nike = new Brand
        {
            Id = Guid.NewGuid(),
            Name = "Nike",
            Slug = "nike"
        };

        var adidas = new Brand
        {
            Id = Guid.NewGuid(),
            Name = "Adidas",
            Slug = "adidas"
        };
        var champion = new Brand
        {
            Id = Guid.NewGuid(),
            Name = "Champion",
            Slug = "champion"
        };

        var gildan = new Brand
        {
            Id = Guid.NewGuid(),
            Name = "Gildan",
            Slug = "gildan"
        };

        var carhartt = new Brand
        {
            Id = Guid.NewGuid(),
            Name = "Carhartt",
            Slug = "carhartt"
        };
        var caps = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Caps",
            Slug = "caps"
        };

        var polos = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Polos",
            Slug = "polos"
        };

        var jackets = new Category
        {
            Id = Guid.NewGuid(),
            Name = "Jackets",
            Slug = "jackets"
        };

        context.Brands.AddRange(
            nike,
            adidas);

        await context.SaveChangesAsync();

        context.Products.AddRange(

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Nike Dri-FIT Tee",
                Slug = "nike-dri-fit-tee",
                Description = "Premium athletic tee",
                BasePrice = 12.99m,
                SKU = "NK-001",
                CategoryId = tshirts.Id,
                BrandId = nike.Id,
                IsActive = true
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Adidas Performance Tee",
                Slug = "adidas-performance-tee",
                Description = "Performance Custom Tee",
                BasePrice = 14.99m,
                SKU = "AD-001",
                CategoryId = tshirts.Id,
                BrandId = adidas.Id,
                IsActive = true
            }

        );

        await context.SaveChangesAsync();
    }
}