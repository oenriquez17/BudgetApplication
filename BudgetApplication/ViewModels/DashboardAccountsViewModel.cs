using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;

namespace BudgetApplication.ViewModels
{
    public class DashboardAccountsViewModel
    {
        List<Account> Accounts { get; set; }
        List<AccountType> AccountTypes { get; set; }
    }
}