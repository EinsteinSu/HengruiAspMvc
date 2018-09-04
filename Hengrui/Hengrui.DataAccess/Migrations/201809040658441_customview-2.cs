namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customview2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filters", "Script", c => c.String(maxLength: 100));
            AddColumn("dbo.Filters", "Parameters", c => c.String(maxLength: 100));
            DropColumn("dbo.Filters", "Condition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Filters", "Condition", c => c.String());
            DropColumn("dbo.Filters", "Parameters");
            DropColumn("dbo.Filters", "Script");
        }
    }
}
