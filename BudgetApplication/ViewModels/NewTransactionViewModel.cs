using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BudgetApplication.ViewModels
{
    public class NewTransactionViewModel
    {
        [Display(Name = "Account")]
        public List<Account> Accounts { get; set; }

        public int SelectedPrimaryAccountId { get; set; }

        public IEnumerable<TransactionType> DebitTransactionTypes { get; set; }

        public IEnumerable<TransactionType> CreditTransactionTypes { get; set; }

        [Display(Name = "Transaction Type")]
        public string SelectedCreditTransactionType { get; set; }

        [Display(Name = "Transaction Type")]
        public string SelectedDebitTransactionType { get; set; }

        [Display(Name = "Transaction Amount")]
        public double TransactionAmount { get; set; }

        public int SelectedTargetAccountId { get; set; }
    }
}