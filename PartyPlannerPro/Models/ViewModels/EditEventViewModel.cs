using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models.ViewModels
{
    public class EditEventViewModel
    {
        public Event Event { get; set; }
        public List<SelectListItem> Venues { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Customers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Vendors { get; set; } = new List<SelectListItem>();
        public List<int> SelectedVendors { get; set; }
    }
}
