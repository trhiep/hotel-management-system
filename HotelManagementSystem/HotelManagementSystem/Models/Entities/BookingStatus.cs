using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int BookingStatusId { get; set; }
        public string BookingStatusName { get; set; } = null!;

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
