using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyPlannerPro.Models
{
    public class Venue
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Venue Name")]
        public string VendorName { get; set; }
        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
         [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Max Capacity")]
        public int MaxCapacity { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();

    }
}
