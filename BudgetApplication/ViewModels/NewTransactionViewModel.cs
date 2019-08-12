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

        // List of actions for debit accounts
        [Display(Name = "Select Action")]
        public List<string> DebitActions = new List<string>(
            new string[]
            {
                "Transfer", //Requires 2 accounts
                "Deposit",
                "Transaction"
            });

        [Display(Name = "Select Action")]
        public List<string> CreditActions = new List<string>(
            new string[]
            {
                "Payment",
                "Transaction"
            });
    }
}