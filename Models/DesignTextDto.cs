using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITClothing.Shared.Models;

public class DesignTextDto
{
    public string Text { get; set; } = string.Empty;

    public string FontFamily { get; set; } = "Arial";

    public string Color { get; set; } = "#000000";

    public int FontSize { get; set; } = 24;

    public int X { get; set; }

    public int Y { get; set; }
}
