namespace FITClothing.Shared.Models;

public class ProductColor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string HexCode { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}