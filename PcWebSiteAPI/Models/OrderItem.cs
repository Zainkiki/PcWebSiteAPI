using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrdersId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual BuyOrder Orders { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
