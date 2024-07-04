using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class PromotionTarget
    {
        public PromotionTarget()
        {
            Promotions = new HashSet<Promotion>();
        }

        public int PromotionTargetId { get; set; }
        public string TargetName { get; set; } = null!;

        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
