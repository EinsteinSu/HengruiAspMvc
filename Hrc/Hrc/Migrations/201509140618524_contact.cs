namespace Hrc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Value", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Value", c => c.String());
        }
    }
}
