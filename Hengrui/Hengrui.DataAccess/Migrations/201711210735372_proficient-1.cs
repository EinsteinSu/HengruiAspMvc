namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proficient1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Sjdw", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Sjdw");
        }
    }
}
