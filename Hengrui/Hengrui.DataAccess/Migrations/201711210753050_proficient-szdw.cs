namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proficientszdw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Szdw", c => c.String(maxLength: 200));
            DropColumn("dbo.Users", "Sjdw");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Sjdw", c => c.String(maxLength: 200));
            DropColumn("dbo.Users", "Szdw");
        }
    }
}
