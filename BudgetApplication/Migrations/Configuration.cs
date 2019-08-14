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
            context.User.AddOrUpdate(x => x.UserId,
                new User() { Username = "oscar1709", Password = "1709" }
                );

            context.AccountType.AddOrUpdate(x => x.AccountTypeId,
                new AccountType() { AccountTypeId = 1, AccountTypeName = "Checkings Account" },
                new AccountType() { AccountTypeId = 2, AccountTypeName = "Savings Account"},
                new AccountType() { AccountTypeId = 3, AccountTypeName = "Credit Card" }
                );

            context.TransactionType.AddOrUpdate(x => x.TransactionTypeId,
                new TransactionType() { TransactionTypeId = 1, TransactionTypeName = "Transaction" },
                new TransactionType() { TransactionTypeId = 2, TransactionTypeName = "Transfer" },
                new TransactionType() { TransactionTypeId = 3, TransactionTypeName = "Deposit" },
                new TransactionType() { TransactionTypeId = 4, TransactionTypeName = "Payment" }
                );
        }
    }
}
