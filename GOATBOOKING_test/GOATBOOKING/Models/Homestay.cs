using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Homestay
{
    
    public long HomestayId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; }

    public string Ward { get; set; }

    public string District { get; set; }

    public string Province { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<ServicesAdvantage> ServicesAdvantages { get; set; } = new List<ServicesAdvantage>();

    public virtual User? User { get; set; }
   
}
