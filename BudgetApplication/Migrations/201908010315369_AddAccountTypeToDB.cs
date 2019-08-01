namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        AccountTypeId = c.Int(nullable: false, identity: true),
                        AccountTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AccountTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountTypes");
        }
    }
}
