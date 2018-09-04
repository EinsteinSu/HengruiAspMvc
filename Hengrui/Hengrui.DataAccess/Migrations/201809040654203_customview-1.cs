namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customview1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Filters", "StoredProcedure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Filters", "StoredProcedure", c => c.Boolean(nullable: false));
        }
    }
}
