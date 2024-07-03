using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class FacilityReport
    {
        public int ReportId { get; set; }
        public int RoomFacilityId { get; set; }
        public DateTime ReportDate { get; set; }
        public string ImageLink { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual RoomFacility RoomFacility { get; set; } = null!;
        public virtual FacilityMaintenanceStatus Status { get; set; } = null!;
    }
}
