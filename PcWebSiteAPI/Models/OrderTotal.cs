using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class OrderTotal
{
    public int OrdersId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal? OrderTotal1 { get; set; }
}
