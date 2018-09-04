namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        FilterId = c.Int(nullable: false),
                        ViewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filters", t => t.FilterId, cascadeDelete: true)
                .ForeignKey("dbo.Views", t => t.ViewId, cascadeDelete: true)
                .Index(t => t.FilterId)
                .Index(t => t.ViewId);
            
            CreateTable(
                "dbo.Filters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        StoredProcedure = c.Boolean(nullable: false),
                        Condition = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Columns = c.String(maxLength: 200),
                        Groups = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomViews", "ViewId", "dbo.Views");
            DropForeignKey("dbo.CustomViews", "FilterId", "dbo.Filters");
            DropIndex("dbo.CustomViews", new[] { "ViewId" });
            DropIndex("dbo.CustomViews", new[] { "FilterId" });
            DropTable("dbo.Views");
            DropTable("dbo.Filters");
            DropTable("dbo.CustomViews");
        }
    }
}
