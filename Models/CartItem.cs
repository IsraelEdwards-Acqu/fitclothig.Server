public class CartItem
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid DesignId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string DesignName { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public string PreviewImageUrl { get; set; } = string.Empty;

    public decimal TotalPrice =>
        UnitPrice * Quantity;
}