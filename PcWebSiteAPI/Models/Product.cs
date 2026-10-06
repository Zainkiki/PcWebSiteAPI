using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ModelInfo { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public int BrandId { get; set; }

    public decimal Price { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();
}
