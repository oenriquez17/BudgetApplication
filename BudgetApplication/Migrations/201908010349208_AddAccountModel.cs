namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        Balance = c.Double(nullable: false),
                        AccountType_AccountTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AccountTypes", t => t.AccountType_AccountTypeId)
                .Index(t => t.AccountType_AccountTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountType_AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Accounts", new[] { "AccountType_AccountTypeId" });
            DropTable("dbo.Accounts");
        }
    }
}
