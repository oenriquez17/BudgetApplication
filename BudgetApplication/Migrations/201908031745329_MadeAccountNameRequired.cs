namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeAccountNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AccountName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AccountName", c => c.String());
        }
    }
}
