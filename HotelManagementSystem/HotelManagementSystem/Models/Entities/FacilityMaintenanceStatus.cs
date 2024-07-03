using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class FacilityMaintenanceStatus
    {
        public FacilityMaintenanceStatus()
        {
            FacilityReports = new HashSet<FacilityReport>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<FacilityReport> FacilityReports { get; set; }
    }
}
