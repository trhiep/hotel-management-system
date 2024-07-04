using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class PromotionHotelRoom
    {
        public int PromotionRoomId { get; set; }
        public int RoomId { get; set; }
        public int PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; } = null!;
        public virtual HotelRoom Room { get; set; } = null!;
    }
}
