using System;
using System.Collections.Generic;

namespace ShopSnap.Models;

public partial class Item
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? ProductPrice { get; set; }
}
