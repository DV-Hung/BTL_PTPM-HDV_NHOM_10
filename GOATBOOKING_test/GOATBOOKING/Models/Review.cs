using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Review
{
    public long ReviewId { get; set; }

    public int Rate { get; set; }

    public string Comment { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public long HomestayId { get; set; }

    public long UserId { get; set; }

    public virtual Homestay? Homestay { get; set; } 

    public virtual User? User { get; set; } 
}
