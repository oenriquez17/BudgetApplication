using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.ViewModels
{
    public class TransactionDashboardViewModel
    {
        public Dictionary<int, List<Transaction>> AccountIdTransactionDict { get; set; }

        [Display (Name = "View transactions for selected account")]
        public Account SelectedAccount { get; set; }

        public List<Account> Accounts { get; set; }
    }
}