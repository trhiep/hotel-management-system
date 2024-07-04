using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionCustomers = new HashSet<PromotionCustomer>();
            PromotionHotelRooms = new HashSet<PromotionHotelRoom>();
        }

        public int PromotionId { get; set; }
        public string PromotionCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public float DiscountValue { get; set; }
        public int Quantity { get; set; }
        public int PromotionTypeId { get; set; }
        public int CreatedBy { get; set; }
        public int StatusId { get; set; }
        public int PromotionTargetId { get; set; }

        public virtual Account CreatedByNavigation { get; set; } = null!;
        public virtual PromotionTarget PromotionTarget { get; set; } = null!;
        public virtual PromotionType PromotionType { get; set; } = null!;
        public virtual PromotionStatus Status { get; set; } = null!;
        public virtual ICollection<PromotionCustomer> PromotionCustomers { get; set; }
        public virtual ICollection<PromotionHotelRoom> PromotionHotelRooms { get; set; }
    }
}
