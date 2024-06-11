using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class Account
    {
        public Account()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
