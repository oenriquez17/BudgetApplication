namespace BudgetApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedTypoInTransactionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Double(nullable: false));
            DropColumn("dbo.Transactions", "Ammount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Ammount", c => c.Double(nullable: false));
            DropColumn("dbo.Transactions", "Amount");
        }
    }
}
