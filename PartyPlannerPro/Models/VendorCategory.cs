using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models
{
    public class VendorCategory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public List<Vendor> Vendors { get; set; } = new List<Vendor>();
    }
}
