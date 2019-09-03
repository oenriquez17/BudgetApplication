using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;

namespace BudgetApplication.ViewModels
{
    public class BillsViewModel
    {
        public List<MonthlyBill> AllBills { get; set; }
        public List<PaidBillsMap> PaidBills { get; set; }
    }
}