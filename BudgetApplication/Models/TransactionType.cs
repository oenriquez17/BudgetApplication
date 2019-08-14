using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApplication.Models
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }

        public static readonly byte Transaction = 1;
        //Debit
        public static readonly byte Transfer = 2;
        public static readonly byte Deposit = 3;
        //Credit
        public static readonly byte Payment = 4;
    }
}