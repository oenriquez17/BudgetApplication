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
        [Key, Column(Order = 0)]
        public int MonthlyBillId { get; set; }

        [Key, Column(Order = 1)]
        public DateTime PaidThisMonth { get; set; }
    }
}