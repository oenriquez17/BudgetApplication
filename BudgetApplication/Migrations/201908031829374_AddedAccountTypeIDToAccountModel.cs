namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccountTypeIDToAccountModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "AccountType_AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Accounts", new[] { "AccountType_AccountTypeId" });
            RenameColumn(table: "dbo.Accounts", name: "AccountType_AccountTypeId", newName: "AccountTypeId");
            AlterColumn("dbo.Accounts", "AccountTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "AccountTypeId");
            AddForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes", "AccountTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            AlterColumn("dbo.Accounts", "AccountTypeId", c => c.Int());
            RenameColumn(table: "dbo.Accounts", name: "AccountTypeId", newName: "AccountType_AccountTypeId");
            CreateIndex("dbo.Accounts", "AccountType_AccountTypeId");
            AddForeignKey("dbo.Accounts", "AccountType_AccountTypeId", "dbo.AccountTypes", "AccountTypeId");
        }
    }
}
