using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public class PaidBillsMap
    {
        public int PaidBillsMapId { get; set; }

        public int MonthlyBillId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }
}