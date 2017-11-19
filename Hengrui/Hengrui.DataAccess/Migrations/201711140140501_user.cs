using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(false));
        }
    }
}