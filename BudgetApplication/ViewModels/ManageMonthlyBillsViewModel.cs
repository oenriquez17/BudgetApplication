using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.ViewModels
{
    public class ManageMonthlyBillsViewModel
    {
        public MonthlyBill NewMonthlyBill { get; set; }

        public List<MonthlyBill> DeleteMonthlyBills { get; set; }

        [Display (Name = "Select Bill To Delete")]
        public int DeleteMonthlyBillId { get; set; }
    }
}