namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillPaidMapModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaidBillsMaps",
                c => new
                    {
                        MonthlyBillId = c.Int(nullable: false),
                        PaidThisMonth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.MonthlyBillId, t.PaidThisMonth });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaidBillsMaps");
        }
    }
}
