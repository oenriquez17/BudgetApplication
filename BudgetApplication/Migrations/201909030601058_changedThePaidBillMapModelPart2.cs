namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedThePaidBillMapModelPart2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PaidBillsMaps");
            AddColumn("dbo.PaidBillsMaps", "PaidBillsMapId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PaidBillsMaps", "MonthlyBillId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PaidBillsMaps", "PaidBillsMapId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PaidBillsMaps");
            AlterColumn("dbo.PaidBillsMaps", "MonthlyBillId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.PaidBillsMaps", "PaidBillsMapId");
            AddPrimaryKey("dbo.PaidBillsMaps", "MonthlyBillId");
        }
    }
}
