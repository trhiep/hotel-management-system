﻿using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public float Salary { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
