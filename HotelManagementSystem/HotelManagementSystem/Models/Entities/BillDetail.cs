using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class BillDetail
    {
        public int BillDetailsId { get; set; }
        public int BillId { get; set; }
        public string Title { get; set; } = null!;
        public float Price { get; set; }
        public string? Note { get; set; }

        public virtual Bill Bill { get; set; } = null!;
    }
}
