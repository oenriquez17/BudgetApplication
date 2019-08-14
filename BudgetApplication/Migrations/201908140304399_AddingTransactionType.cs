namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTransactionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransactionTypeId = c.Int(nullable: false, identity: true),
                        TransactionTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TransactionTypeId);
            
            AddColumn("dbo.Transactions", "TransactionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "TransactionTypeId");
            AddForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes", "TransactionTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropColumn("dbo.Transactions", "TransactionTypeId");
            DropTable("dbo.TransactionTypes");
        }
    }
}
