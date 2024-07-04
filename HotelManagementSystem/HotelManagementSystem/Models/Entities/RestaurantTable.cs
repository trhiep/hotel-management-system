using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class RestaurantTable
    {
        public RestaurantTable()
        {
            RestaurantBookings = new HashSet<RestaurantBooking>();
        }

        public int TableId { get; set; }
        public int Slot { get; set; }

        public virtual ICollection<RestaurantBooking> RestaurantBookings { get; set; }
    }
}
