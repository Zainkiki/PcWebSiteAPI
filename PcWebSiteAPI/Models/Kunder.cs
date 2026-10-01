using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class Kunder
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Gade { get; set; } = null!;

    public int PostNr { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; set; } = new List<BuyOrder>();
}
