using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class FacilityReport
    {
        public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public string ImageLink { get; set; } = null!;
        public int RoomFacilityId { get; set; }
        public int MaintenanceStatusId { get; set; }

        public virtual FacilityMaintenanceStatus MaintenanceStatus { get; set; } = null!;
        public virtual RoomFacility RoomFacility { get; set; } = null!;
    }
}
