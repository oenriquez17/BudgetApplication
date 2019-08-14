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

        [Display(Name = "Transaction Type")]
        public IEnumerable<TransactionType> DebitTransactionTypes { get; set; }

        [Display(Name = "Transaction Type")]
        public IEnumerable<TransactionType> CreditTransactionTypes { get; set; }
    }
}