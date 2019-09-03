using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public class MonthlyBill
    {
        public int MonthlyBillId { get; set; }

        [Display (Name = "Bill Name")]
        public string MonthlyBillName { get; set; }

        public int UserId { get; set; }
    }
}