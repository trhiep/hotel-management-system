using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class Account
    {
        public Account()
        {
            Promotions = new HashSet<Promotion>();
            ResetPasswordOtps = new HashSet<ResetPasswordOtp>();
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public bool IsEnable { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<ResetPasswordOtp> ResetPasswordOtps { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
