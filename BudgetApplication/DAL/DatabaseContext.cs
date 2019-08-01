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

        public DatabaseContext() : base("BudgetAppDBConnetion")
        {

        }


    }
}