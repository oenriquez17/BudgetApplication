using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.Collections;

namespace BudgetApplication.ViewModels
{
    public class TransactionsViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Account> Accounts { get; set; }
    }
}