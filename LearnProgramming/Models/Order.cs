using System;
using System.Collections.Generic;

namespace RMA.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? TotalAmount { get; set; }

    public int? Cgst { get; set; }

    public int? Sgst { get; set; }

    public string? GrandTotal { get; set; }
}
