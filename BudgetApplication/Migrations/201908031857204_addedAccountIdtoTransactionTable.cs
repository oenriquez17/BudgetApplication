namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAccountIdtoTransactionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Account_AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "Account_AccountId" });
            RenameColumn(table: "dbo.Transactions", name: "Account_AccountId", newName: "AccountId");
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "AccountId");
            AddForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "AccountId", newName: "Account_AccountId");
            CreateIndex("dbo.Transactions", "Account_AccountId");
            AddForeignKey("dbo.Transactions", "Account_AccountId", "dbo.Accounts", "AccountId");
        }
    }
}
