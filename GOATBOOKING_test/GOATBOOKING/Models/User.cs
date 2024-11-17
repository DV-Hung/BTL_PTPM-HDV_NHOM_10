using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; } 

    public int Gender { get; set; }

    public string FullName { get; set; } 

    public string Avatar { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Homestay> Homestays { get; set; } = new List<Homestay>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
