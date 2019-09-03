namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBillModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyBills",
                c => new
                    {
                        MonthlyBillId = c.Int(nullable: false, identity: true),
                        MonthlyBillName = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonthlyBillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonthlyBills");
        }
    }
}
