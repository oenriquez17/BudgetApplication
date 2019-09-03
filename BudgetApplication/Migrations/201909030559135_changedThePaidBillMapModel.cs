namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedThePaidBillMapModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PaidBillsMaps");
            AddColumn("dbo.PaidBillsMaps", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.PaidBillsMaps", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.PaidBillsMaps", "MonthlyBillId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PaidBillsMaps", "MonthlyBillId");
            DropColumn("dbo.PaidBillsMaps", "PaidThisMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaidBillsMaps", "PaidThisMonth", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.PaidBillsMaps");
            AlterColumn("dbo.PaidBillsMaps", "MonthlyBillId", c => c.Int(nullable: false));
            DropColumn("dbo.PaidBillsMaps", "Year");
            DropColumn("dbo.PaidBillsMaps", "Month");
            AddPrimaryKey("dbo.PaidBillsMaps", new[] { "MonthlyBillId", "PaidThisMonth" });
        }
    }
}
