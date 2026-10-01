using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class BuyOrder
{
    public int OrdersId { get; set; }

    public int SaelgerId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual Kunder Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Saelger Saelger { get; set; } = null!;
}
