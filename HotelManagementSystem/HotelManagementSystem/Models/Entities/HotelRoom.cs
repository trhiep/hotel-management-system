using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class HotelRoom
    {
        public HotelRoom()
        {
            PromotionHotelRooms = new HashSet<PromotionHotelRoom>();
            RoomBookings = new HashSet<RoomBooking>();
            RoomFacilities = new HashSet<RoomFacility>();
        }

        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public float Price { get; set; }

        public virtual ICollection<PromotionHotelRoom> PromotionHotelRooms { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
    }
}
