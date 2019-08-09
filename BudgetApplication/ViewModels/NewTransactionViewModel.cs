using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;

namespace BudgetApplication.ViewModels
{
    public class NewTransactionViewModel
    {
        List<Account> Accounts { get; set; }
        Transaction PrimaryTransaction { get; set; }
        Transaction SecondaryTransaction { get; set; }
    }
}