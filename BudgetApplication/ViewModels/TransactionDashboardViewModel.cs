using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;

namespace BudgetApplication.ViewModels
{
    public class TransactionDashboardViewModel
    {
        public Dictionary<int, List<Transaction>> AccountIdTransactionDict { get; set; }
        public List<Account> Accounts { get; set; }
    }
}