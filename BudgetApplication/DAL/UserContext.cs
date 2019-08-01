using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BudgetApplication.Models;

namespace BudgetApplication.DAL
{
    public class UserContext : DbContext
    {
        DbSet<User> User { get; set; }

        public UserContext() : base("BudgetAppDBConnetion")
        {

        }
    }
}