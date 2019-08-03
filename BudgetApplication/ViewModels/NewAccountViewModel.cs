using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;

namespace BudgetApplication.ViewModels
{
    public class NewAccountViewModel
    {
        public Account Account { get; set; }
        public IEnumerable<AccountType> AccountTypes { get; set; }
    }
}