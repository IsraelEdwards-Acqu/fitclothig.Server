namespace FITClothing.Shared.Models;

public class CartItem
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid? DesignId { get; set; }

    public string ProductName { get; set; } = "";

    public string DesignName { get; set; } = "";

    public string PreviewImage { get; set; } = "";

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public Guid? CartId { get; set; }

    public decimal TotalPrice =>
        UnitPrice * Quantity;
}