using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.ViewModels
{
    public class NewTransactionViewModel
    {
        [Display(Name = "Account")]
        public List<Account> Accounts { get; set; }
        public Transaction PrimaryTransaction { get; set; }
        public Transaction SecondaryTransaction { get; set; }
    }
}