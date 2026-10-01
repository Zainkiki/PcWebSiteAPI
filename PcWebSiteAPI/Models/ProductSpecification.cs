using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class ProductSpecification
{
    public int ProductSpecificationId { get; set; }

    public int ProductId { get; set; }

    public int SpecificationId { get; set; }

    public string SpecificationValue { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Specification Specification { get; set; } = null!;
}
