using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Service
{
    public long ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public virtual ICollection<ServicesAdvantage> ServicesAdvantages { get; set; } = new List<ServicesAdvantage>();
}
