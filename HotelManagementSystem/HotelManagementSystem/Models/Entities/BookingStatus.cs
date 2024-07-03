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

        public int BookStatusId { get; set; }
        public int Name { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
