namespace FITClothing.Shared.Models;

public class Promotion
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Link { get; set; } = string.Empty;

    public string BackgroundColor { get; set; } = "#FFFFFF";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}