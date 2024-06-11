using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionCustomers = new HashSet<PromotionCustomer>();
            PromotionItems = new HashSet<PromotionItem>();
            PromotionRooms = new HashSet<PromotionRoom>();
        }

        public int PromotionId { get; set; }
        public string PromotionCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public float DiscountValue { get; set; }
        public int Quantity { get; set; }
        public int PromotionTypeId { get; set; }

        public virtual PromotionType PromotionType { get; set; } = null!;
        public virtual ICollection<PromotionCustomer> PromotionCustomers { get; set; }
        public virtual ICollection<PromotionItem> PromotionItems { get; set; }
        public virtual ICollection<PromotionRoom> PromotionRooms { get; set; }
    }
}
