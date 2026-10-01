using System;
using System.Collections.Generic;

namespace PcWebSiteAPI.Models;

public partial class Saelger
{
    public int SaelgerId { get; set; }

    public string Virksomhedsnavn { get; set; } = null!;

    public int Cvr { get; set; }

    public string Gade { get; set; } = null!;

    public int PostNr { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; set; } = new List<BuyOrder>();
}
