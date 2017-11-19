using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class changecontact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Contract_ProjectId", "dbo.Contracts");
            DropIndex("dbo.Contacts", new[] {"Contract_ProjectId"});
            AddColumn("dbo.Departments", "Contact_Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Departments", "Contact_Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Departments", "Contact_Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Departments", "Contact_WeiChat", c => c.String(maxLength: 50));
            AddColumn("dbo.Departments", "Contact_QQ", c => c.String(maxLength: 20));
            AddColumn("dbo.Departments", "Contact_Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Departments", "Contact_Address", c => c.String(maxLength: 200));
            AddColumn("dbo.Users", "Contact_Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Contact_Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Contact_Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Contact_WeiChat", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Contact_QQ", c => c.String(maxLength: 20));
            AddColumn("dbo.Users", "Contact_Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "Contact_Address", c => c.String(maxLength: 200));
            AddColumn("dbo.Projects", "Lxr_Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Lxr_Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Lxr_Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Lxr_WeiChat", c => c.String(maxLength: 50));
            AddColumn("dbo.Projects", "Lxr_QQ", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Lxr_Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Projects", "Lxr_Address", c => c.String(maxLength: 200));
            AddColumn("dbo.Projects", "Wtr_Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Wtr_Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Wtr_Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Wtr_WeiChat", c => c.String(maxLength: 50));
            AddColumn("dbo.Projects", "Wtr_QQ", c => c.String(maxLength: 20));
            AddColumn("dbo.Projects", "Wtr_Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Projects", "Wtr_Address", c => c.String(maxLength: 200));
            AddColumn("dbo.Contracts", "Fr_Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Contracts", "Fr_Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Contracts", "Fr_Mobile", c => c.String(maxLength: 20));
            AddColumn("dbo.Contracts", "Fr_WeiChat", c => c.String(maxLength: 50));
            AddColumn("dbo.Contracts", "Fr_QQ", c => c.String(maxLength: 20));
            AddColumn("dbo.Contracts", "Fr_Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "Fr_Address", c => c.String(maxLength: 200));
            DropColumn("dbo.Departments", "Contacts");
            DropColumn("dbo.Users", "Contacts");
            DropColumn("dbo.Projects", "Lxr");
            DropColumn("dbo.Projects", "Wtr");
            DropTable("dbo.Contacts");
        }

        public override void Down()
        {
            CreateTable(
                    "dbo.Contacts",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Type = c.Int(false),
                        Value = c.String(maxLength: 200),
                        Contract_ProjectId = c.Int()
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Projects", "Wtr", c => c.String());
            AddColumn("dbo.Projects", "Lxr", c => c.String());
            AddColumn("dbo.Users", "Contacts", c => c.String());
            AddColumn("dbo.Departments", "Contacts", c => c.String());
            DropColumn("dbo.Contracts", "Fr_Address");
            DropColumn("dbo.Contracts", "Fr_Email");
            DropColumn("dbo.Contracts", "Fr_QQ");
            DropColumn("dbo.Contracts", "Fr_WeiChat");
            DropColumn("dbo.Contracts", "Fr_Mobile");
            DropColumn("dbo.Contracts", "Fr_Phone");
            DropColumn("dbo.Contracts", "Fr_Name");
            DropColumn("dbo.Projects", "Wtr_Address");
            DropColumn("dbo.Projects", "Wtr_Email");
            DropColumn("dbo.Projects", "Wtr_QQ");
            DropColumn("dbo.Projects", "Wtr_WeiChat");
            DropColumn("dbo.Projects", "Wtr_Mobile");
            DropColumn("dbo.Projects", "Wtr_Phone");
            DropColumn("dbo.Projects", "Wtr_Name");
            DropColumn("dbo.Projects", "Lxr_Address");
            DropColumn("dbo.Projects", "Lxr_Email");
            DropColumn("dbo.Projects", "Lxr_QQ");
            DropColumn("dbo.Projects", "Lxr_WeiChat");
            DropColumn("dbo.Projects", "Lxr_Mobile");
            DropColumn("dbo.Projects", "Lxr_Phone");
            DropColumn("dbo.Projects", "Lxr_Name");
            DropColumn("dbo.Users", "Contact_Address");
            DropColumn("dbo.Users", "Contact_Email");
            DropColumn("dbo.Users", "Contact_QQ");
            DropColumn("dbo.Users", "Contact_WeiChat");
            DropColumn("dbo.Users", "Contact_Mobile");
            DropColumn("dbo.Users", "Contact_Phone");
            DropColumn("dbo.Users", "Contact_Name");
            DropColumn("dbo.Departments", "Contact_Address");
            DropColumn("dbo.Departments", "Contact_Email");
            DropColumn("dbo.Departments", "Contact_QQ");
            DropColumn("dbo.Departments", "Contact_WeiChat");
            DropColumn("dbo.Departments", "Contact_Mobile");
            DropColumn("dbo.Departments", "Contact_Phone");
            DropColumn("dbo.Departments", "Contact_Name");
            CreateIndex("dbo.Contacts", "Contract_ProjectId");
            AddForeignKey("dbo.Contacts", "Contract_ProjectId", "dbo.Contracts", "ProjectId");
        }
    }
}