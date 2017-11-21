namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "OriginalId", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "OriginalId");
        }
    }
}
