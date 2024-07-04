using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class PromotionStatus
    {
        public PromotionStatus()
        {
            Promotions = new HashSet<Promotion>();
        }

        public int PromotionStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
