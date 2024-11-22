using System;
using System.Collections.Generic;

namespace RMA.Models;

public partial class MenuItem
{
    public int ItemId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Category { get; set; }

    public string? ImagePath { get; set; }
}
