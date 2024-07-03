using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class PromotionItem
    {
        public int PromotionId { get; set; }
        public int ItemId { get; set; }
        public int PromotionItemId { get; set; }

        public virtual MenuItem Item { get; set; } = null!;
        public virtual Promotion Promotion { get; set; } = null!;
    }
}
