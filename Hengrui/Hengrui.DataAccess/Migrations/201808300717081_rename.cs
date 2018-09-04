namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractStatus", newName: "ContractStates");
            RenameTable(name: "dbo.DocumentStatus", newName: "DocumentationStates");
            RenameTable(name: "dbo.Emergencies", newName: "ProjectLevels");
            RenameTable(name: "dbo.PaperStatus", newName: "PaperStates");
            RenameTable(name: "dbo.ProjectStatus", newName: "ProjectStates");
            AlterColumn("dbo.Gcgks", "Wxxfl", c => c.String(maxLength: 20));
            AlterColumn("dbo.Sjdws", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Sjdws", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Sjdws", "Sjzz", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sjdws", "Sjzz", c => c.String());
            AlterColumn("dbo.Sjdws", "Address", c => c.String());
            AlterColumn("dbo.Sjdws", "Name", c => c.String());
            AlterColumn("dbo.Gcgks", "Wxxfl", c => c.String());
            RenameTable(name: "dbo.ProjectStates", newName: "ProjectStatus");
            RenameTable(name: "dbo.PaperStates", newName: "PaperStatus");
            RenameTable(name: "dbo.ProjectLevels", newName: "Emergencies");
            RenameTable(name: "dbo.DocumentationStates", newName: "DocumentStatus");
            RenameTable(name: "dbo.ContractStates", newName: "ContractStatus");
        }
    }
}
