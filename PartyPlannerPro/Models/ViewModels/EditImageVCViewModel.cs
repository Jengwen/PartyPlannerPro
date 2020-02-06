using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models.ViewModels
{
    public class EditImageVCViewModel
    {
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }
        public VendorCategory vendorCategory { get; set; }
    }
}
