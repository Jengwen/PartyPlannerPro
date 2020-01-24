using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyPlannerPro.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public double Budget { get; set; }
        [Required]
        [Display(Name = "Total Number of Guests")]
        public int TotalGuests { get; set; }
        [Required]
        [Display(Name = "Party Planner")]
        public string ApplicationUserId { get; set; }
        [Display(Name= "Venue")]
        public int VenueId { get; set; }
        public ApplicationUser User {get; set;}
        [Display(Name= "Event Vendors")]
        public List<EventVendor> EventVendors { get; set; } = new List<EventVendor>();

    }
}
