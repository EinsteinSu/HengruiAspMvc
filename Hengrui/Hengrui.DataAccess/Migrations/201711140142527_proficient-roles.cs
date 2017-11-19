using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class proficientroles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Roles", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("dbo.Users", "Roles", c => c.String());
        }
    }
}