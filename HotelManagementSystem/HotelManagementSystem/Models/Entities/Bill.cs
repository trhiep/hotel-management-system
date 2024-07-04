using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BillId { get; set; }
        public int? RoomBookingId { get; set; }
        public bool IsPaid { get; set; }

        public virtual RoomBooking? RoomBooking { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
