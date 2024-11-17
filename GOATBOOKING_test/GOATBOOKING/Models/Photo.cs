using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Photo
{
    public long PhotoId { get; set; }

    public string? NamePhoto { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public long HomestayId { get; set; }

    public virtual Homestay Homestay { get; set; } = null!;
}
