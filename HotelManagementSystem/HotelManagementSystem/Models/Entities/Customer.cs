using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            MenuBookings = new HashSet<MenuBooking>();
            PromotionCustomers = new HashSet<PromotionCustomer>();
            RestaurantBookings = new HashSet<RestaurantBooking>();
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CitizenId { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public bool IsLoyal { get; set; }
        public bool IsAllowReceiveInformaton { get; set; }

        public virtual ICollection<MenuBooking> MenuBookings { get; set; }
        public virtual ICollection<PromotionCustomer> PromotionCustomers { get; set; }
        public virtual ICollection<RestaurantBooking> RestaurantBookings { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
