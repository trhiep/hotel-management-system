﻿using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class Facility
    {
        public Facility()
        {
            RoomFacilities = new HashSet<RoomFacility>();
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; } = null!;
        public float Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<RoomFacility> RoomFacilities { get; set; }
    }
}
