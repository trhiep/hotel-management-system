using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int BookStatusId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
