using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class OrderHistory
{
    public int OrdersId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int SaelgerId { get; set; }

    public string Virksomhedsnavn { get; set; } = null!;

    public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public string ModelInfo { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? LineTotal { get; set; }
}
