namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BudgetApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BudgetApplication.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BudgetApplication.DAL.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
