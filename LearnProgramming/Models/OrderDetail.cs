using System;
using System.Collections.Generic;

namespace RMA.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ItemId { get; set; }

    public int? Quantity { get; set; }

    public int? SubTotal { get; set; }
}
