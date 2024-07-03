using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class MenuCategory
    {
        public MenuCategory()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
