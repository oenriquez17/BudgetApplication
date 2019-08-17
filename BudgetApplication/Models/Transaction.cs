using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApplication.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }

        public double Amount { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public string Comments { get; set; }
    }
}