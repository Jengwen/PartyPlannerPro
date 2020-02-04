using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyPlannerPro.Models.ViewModels.Report
{
    public class Spending   
    {
        public Customer customer { get; set; }
        public int totalSpending { get; set; }
    }
}
