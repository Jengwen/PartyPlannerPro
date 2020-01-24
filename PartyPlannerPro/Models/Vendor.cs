using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyPlannerPro.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        public int VendorCategoryId { get; set; }
        public VendorCategory Category { get; set; }
        public List<EventVendor> EventVendors { get; set; } = new List<EventVendor>();
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
