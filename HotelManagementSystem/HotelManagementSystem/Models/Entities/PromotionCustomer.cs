using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class PromotionCustomer
    {
        public int PromotionCustomerId { get; set; }
        public int CustomerId { get; set; }
        public int PromotionId { get; set; }
        public bool IsUsed { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Promotion Promotion { get; set; } = null!;
    }
}
