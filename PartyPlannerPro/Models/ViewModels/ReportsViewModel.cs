using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyPlannerPro.Models.ViewModels.Report;

namespace PartyPlannerPro.Models.ViewModels
{
    public class ReportsViewModel
    {
        public List<PopularVenue> topVenues { get; set; } = new List<PopularVenue>();
        public List<Spending> topSpending { get; set; } = new List<Spending>();
    }
}
