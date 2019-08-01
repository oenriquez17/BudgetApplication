namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountUserModelForTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.AccountId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountUsers");
        }
    }
}
