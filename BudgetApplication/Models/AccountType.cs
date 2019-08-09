using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetApplication.Models
{
    public class AccountType
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

        public static readonly byte Checkings = 1;
        public static readonly byte Savings = 2;
        public static readonly byte CreditCard = 3;
    }
}