using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Booking
{
    public long BookingId { get; set; }

    public long CheckInDate { get; set; }

    public long CheckOutDate { get; set; }

    public decimal DepositPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public int Status { get; set; }

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual User? User { get; set; }
}
