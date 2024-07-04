using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class RoomBooking
    {
        public RoomBooking()
        {
            Bills = new HashSet<Bill>();
        }

        public int RoomBookingId { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BookingStatusId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BookingStatus BookingStatus { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual HotelRoom Room { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
