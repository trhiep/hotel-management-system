using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class ResetPasswordOtp
    {
        public int Otpid { get; set; }
        public int AccountId { get; set; }
        public string Otpstring { get; set; } = null!;
        public bool IsUsed { get; set; }
        public DateTime GeneratedTime { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
