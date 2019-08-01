namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Ammount = c.Double(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Account_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Account_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Account_AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "Account_AccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
