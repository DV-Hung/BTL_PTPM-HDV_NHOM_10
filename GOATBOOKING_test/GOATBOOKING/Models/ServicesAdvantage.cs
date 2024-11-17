using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class ServicesAdvantage
{
    public long HomestayId { get; set; }

    public long ServiceId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Homestay Homestay { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
