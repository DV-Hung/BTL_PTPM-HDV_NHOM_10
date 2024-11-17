using System;
using System.Collections.Generic;

namespace GOATBOOKING.Models;

public partial class Room
{
    public long RoomId { get; set; }

    public string RoomName { get; set; }

    public int RoomType { get; set; } // 1 đơn, 2 đôi

    public decimal Price { get; set; }

    public int Status { get; set; } // 1 copnf phòng, 0 là hết

    public long CreatedAt { get; set; }

    public long UpdatedAt { get; set; }

    public long? HomestayId { get; set; }

    public long? BookingId { get; set; }

    public virtual Booking? Booking { get; set; } 

    public virtual Homestay? Homestay { get; set; }
}
