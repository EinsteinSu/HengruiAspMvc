namespace Hrc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class branch11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Acronym = c.String(nullable: false, maxLength: 3),
                        Qddd = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Value = c.String(),
                        Branch_BranchID = c.Int(),
                        Branch_BranchID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchID)
                .ForeignKey("dbo.Branches", t => t.Branch_BranchID1)
                .Index(t => t.Branch_BranchID)
                .Index(t => t.Branch_BranchID1);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        ParameterID = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 20),
                        Value = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ParameterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Branch_BranchID1", "dbo.Branches");
            DropForeignKey("dbo.Contacts", "Branch_BranchID", "dbo.Branches");
            DropIndex("dbo.Contacts", new[] { "Branch_BranchID1" });
            DropIndex("dbo.Contacts", new[] { "Branch_BranchID" });
            DropTable("dbo.Parameters");
            DropTable("dbo.Contacts");
            DropTable("dbo.Branches");
        }
    }
}
