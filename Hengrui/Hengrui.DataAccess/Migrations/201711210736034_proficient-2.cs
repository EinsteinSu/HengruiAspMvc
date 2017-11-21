namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proficient2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Sjdw", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Sjdw", c => c.String());
        }
    }
}
