using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models.ViewModels
{
    public class UploadVenueViewModel
    {
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }
        public Venue venue { get; set; }
    }
}
