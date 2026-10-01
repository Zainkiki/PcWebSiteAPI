using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class ProductList
{
    public int ProductId { get; set; }

    public string ModelInfo { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? SpecificationName { get; set; }

    public string? SpecificationValue { get; set; }

    public string? Unit { get; set; }
}
