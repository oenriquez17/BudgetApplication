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
        public List<Account> Accounts { get; set; }

        [Display(Name = "Account")]
        [Required]
        public int SelectedPrimaryAccountId { get; set; }

        public IEnumerable<TransactionType> DebitTransactionTypes { get; set; }

        public IEnumerable<TransactionType> CreditTransactionTypes { get; set; }

        [Display(Name = "Transaction Type")]
        //Special Validation
        public string SelectedCreditTransactionType { get; set; }

        [Display(Name = "Transaction Type")]
        //Special Validation
        public string SelectedDebitTransactionType { get; set; }

        [Display(Name = "Transaction Amount")]
        //Special Validation
        public double TransactionAmount { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Transfer To Account")]
        //Special Validation
        public int SelectedTargetAccountId { get; set; }
    }
}