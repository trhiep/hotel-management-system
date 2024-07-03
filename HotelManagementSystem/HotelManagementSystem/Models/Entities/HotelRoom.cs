using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            PromotionRooms = new HashSet<PromotionRoom>();
            RoomBookings = new HashSet<RoomBooking>();
            RoomFacilities = new HashSet<RoomFacility>();
        }

        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public float Price { get; set; }

        public virtual ICollection<PromotionRoom> PromotionRooms { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
    }
}
