using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models
{
    public class VendorCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
    }
}
