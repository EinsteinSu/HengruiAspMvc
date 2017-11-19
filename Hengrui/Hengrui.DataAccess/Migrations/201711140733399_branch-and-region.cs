using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class branchandregion : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.Areas", "Regions");
            RenameColumn("dbo.Projects", "Area_Id", "Region_Id");
            RenameIndex("dbo.Projects", "IX_Area_Id", "IX_Region_Id");
            CreateTable(
                    "dbo.Branches",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        ContactUserId = c.Int(false),
                        Contact_Name = c.String(maxLength: 20),
                        Contact_Phone = c.String(maxLength: 20),
                        Contact_Mobile = c.String(maxLength: 20),
                        Contact_WeiChat = c.String(maxLength: 50),
                        Contact_QQ = c.String(maxLength: 20),
                        Contact_Email = c.String(maxLength: 100),
                        Contact_Address = c.String(maxLength: 200)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ContactUserId, true)
                .Index(t => t.ContactUserId);

            AddColumn("dbo.Cities", "Branch_Id", c => c.Int());
            CreateIndex("dbo.Cities", "Branch_Id");
            AddForeignKey("dbo.Cities", "Branch_Id", "dbo.Branches", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Branches", "ContactUserId", "dbo.Users");
            DropForeignKey("dbo.Cities", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.Cities", new[] {"Branch_Id"});
            DropIndex("dbo.Branches", new[] {"ContactUserId"});
            DropColumn("dbo.Cities", "Branch_Id");
            DropTable("dbo.Branches");
            RenameIndex("dbo.Projects", "IX_Region_Id", "IX_Area_Id");
            RenameColumn("dbo.Projects", "Region_Id", "Area_Id");
            RenameTable("dbo.Regions", "Areas");
        }
    }
}