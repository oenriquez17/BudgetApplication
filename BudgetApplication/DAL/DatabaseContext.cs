using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BudgetApplication.Models;

namespace BudgetApplication.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<AccountUser> AccountUser { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<MonthlyBill> MonthlyBill { get; set; }
        public DbSet<PaidBillsMap> PaidBillsMap { get; set; }

        public DatabaseContext() : base("BudgetAppDBConnetion")
        {

        }


    }
}