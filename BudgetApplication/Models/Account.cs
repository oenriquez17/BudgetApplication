using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BudgetApplication.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Display(Name = "Account Type")]
        public int AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }

        public double Balance { get; set; }
    }
}