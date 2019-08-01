using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApplication.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public double Ammount { get; set; }
        public Account Account { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string Comments { get; set; }
    }
}