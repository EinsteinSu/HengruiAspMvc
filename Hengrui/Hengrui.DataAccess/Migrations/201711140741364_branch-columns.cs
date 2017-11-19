using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class branchcolumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Cities", new[] {"Branch_Id"});
            AddColumn("dbo.Branches", "Acronym", c => c.String(maxLength: 5));
            AddColumn("dbo.Branches", "CityId", c => c.Int(false));
            AlterColumn("dbo.Branches", "Name", c => c.String(false, 20));
            CreateIndex("dbo.Branches", "CityId");
            AddForeignKey("dbo.Branches", "CityId", "dbo.Cities", "Id", true);
            DropColumn("dbo.Cities", "Branch_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Cities", "Branch_Id", c => c.Int());
            DropForeignKey("dbo.Branches", "CityId", "dbo.Cities");
            DropIndex("dbo.Branches", new[] {"CityId"});
            AlterColumn("dbo.Branches", "Name", c => c.String());
            DropColumn("dbo.Branches", "CityId");
            DropColumn("dbo.Branches", "Acronym");
            CreateIndex("dbo.Cities", "Branch_Id");
            AddForeignKey("dbo.Cities", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}