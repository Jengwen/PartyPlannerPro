using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models
{
    public class EventVendor
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int VendorId { get; set; }
        public Event Event {get; set;}
        public Vendor Vendor { get; set; }

    }
}
