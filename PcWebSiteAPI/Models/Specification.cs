using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class Specification
{
    public int SpecificationId { get; set; }

    public string SpecificationName { get; set; } = null!;

    public string? Unit { get; set; }

    public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();
}
