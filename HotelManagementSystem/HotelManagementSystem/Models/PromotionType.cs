using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class PromotionType
    {
        public PromotionType()
        {
            Promotions = new HashSet<Promotion>();
        }

        public int PromotionTypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}
