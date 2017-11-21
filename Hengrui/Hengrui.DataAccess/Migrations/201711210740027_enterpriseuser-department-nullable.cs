namespace Hengrui.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enterpriseuserdepartmentnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
