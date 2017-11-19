using System.Data.Entity.Migrations;

namespace Hengrui.DataAccess.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Departments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 30),
                        Contacts = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 20),
                        Gender = c.Int(false),
                        Password = c.String(false),
                        Type = c.Int(false),
                        BirthDate = c.DateTime(),
                        Contacts = c.String(),
                        Deleted = c.Boolean(false),
                        DepartmentId = c.Int(),
                        Zy = c.Int(),
                        Roles = c.String(),
                        Discriminator = c.String(false, 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, true)
                .Index(t => t.DepartmentId);

            CreateTable(
                    "dbo.UserPhotoes",
                    c => new
                    {
                        UserId = c.Int(false),
                        Photo = c.Binary()
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.Projects",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 200),
                        Xmlb = c.Int(false),
                        Tzlb = c.Int(false),
                        Jsdw = c.String(false, 200),
                        Instance = c.Int(false),
                        CreateTime = c.DateTime(false),
                        Lxr = c.String(),
                        Wtr = c.String(),
                        CreateUserId = c.Int(false),
                        Paused = c.Boolean(false),
                        Deleted = c.Boolean(false),
                        Area_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Area_Id)
                .ForeignKey("dbo.Users", t => t.CreateUserId, true)
                .Index(t => t.CreateUserId)
                .Index(t => t.Area_Id);

            CreateTable(
                    "dbo.Areas",
                    c => new
                    {
                        Id = c.Int(false, true),
                        CityId = c.Int(false),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, true)
                .Index(t => t.CityId);

            CreateTable(
                    "dbo.Cities",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Contracts",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        Qx = c.Int(false),
                        Htje = c.Decimal(false, 18, 2),
                        Zk = c.String(maxLength: 50),
                        Jmje = c.Decimal(false, 18, 2),
                        Ysje = c.Decimal(false, 18, 2),
                        Discount_ProjectId = c.Int()
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ContractDiscounts", t => t.Discount_ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.Discount_ProjectId);

            CreateTable(
                    "dbo.ContractDiscounts",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        Description = c.String()
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);

            CreateTable(
                    "dbo.Contacts",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Type = c.Int(false),
                        Value = c.String(maxLength: 200),
                        Contract_ProjectId = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_ProjectId)
                .Index(t => t.Contract_ProjectId);

            CreateTable(
                    "dbo.ProjectContractPayments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Time = c.Int(false),
                        Percent = c.Decimal(false, 18, 2),
                        Money = c.Decimal(false, 18, 2),
                        Fksm = c.String(),
                        Contract_ProjectId = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.Contract_ProjectId)
                .Index(t => t.Contract_ProjectId);

            CreateTable(
                    "dbo.ContractStatus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Status = c.Int(false),
                        Czsj = c.DateTime(),
                        Version = c.Binary(false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Description = c.String(maxLength: 50),
                        Czy_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Czy_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.DocumentStatus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Status = c.Int(false),
                        Czsj = c.DateTime(),
                        Version = c.Binary(false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Description = c.String(maxLength: 50),
                        Czy_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Czy_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.Emergencies",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        Level = c.Int(false),
                        Description = c.String(),
                        Czy_Id = c.Int()
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.Czy_Id);

            CreateTable(
                    "dbo.Gcgks",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Xh = c.Int(false),
                        Dh = c.String(maxLength: 300),
                        Jgxs = c.String(maxLength: 100),
                        Jzcs = c.String(maxLength: 20),
                        Jzgd = c.String(maxLength: 20),
                        Nhdj = c.String(maxLength: 20),
                        Wxxfl = c.String(),
                        Gcgk_Id = c.Int(),
                        Jzfl_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gcgks", t => t.Gcgk_Id)
                .ForeignKey("dbo.Jzfls", t => t.Jzfl_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Gcgk_Id)
                .Index(t => t.Jzfl_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.Jzfls",
                    c => new
                    {
                        Id = c.Int(false, true),
                        PId = c.Int(false),
                        Name = c.String(maxLength: 20),
                        DisplayName = c.String(maxLength: 100),
                        Description = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Htbhs",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        Year = c.Int(false),
                        Number = c.Int(false)
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);

            CreateTable(
                    "dbo.OwnerLogins",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        UserName = c.String(false, 20),
                        Password = c.String(false, 200)
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);

            CreateTable(
                    "dbo.Papers",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Zy = c.Int(false),
                        Count = c.Int(false),
                        BackCount = c.Int(false),
                        HftCount = c.Int(false),
                        Czy_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Czy_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.PaperStatus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Status = c.Int(false),
                        Czsj = c.DateTime(),
                        Version = c.Binary(false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Description = c.String(maxLength: 50),
                        Czy_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Czy_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.PaymentAndBillings",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Payment_IsValid = c.Boolean(false),
                        Payment_Amount = c.Decimal(false, 18, 2),
                        Payment_Date = c.DateTime(),
                        Billing_IsValid = c.Boolean(false),
                        Billing_Amount = c.Decimal(false, 18, 2),
                        Billing_Date = c.DateTime(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.ProjectStatus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Status = c.Int(false),
                        Czsj = c.DateTime(),
                        Version = c.Binary(false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Description = c.String(maxLength: 50),
                        Czy_Id = c.Int(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Czy_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Czy_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.Sjdws",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(),
                        Address = c.String(),
                        Sjzz = c.String(),
                        Project_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);

            CreateTable(
                    "dbo.Xmbhs",
                    c => new
                    {
                        ProjectId = c.Int(false),
                        Year = c.Int(false),
                        Number = c.Int(false)
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Xmbhs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Sjdws", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectStatus", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectStatus", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.PaymentAndBillings", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.PaperStatus", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.PaperStatus", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.Papers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Papers", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.OwnerLogins", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Htbhs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Gcgks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Gcgks", "Jzfl_Id", "dbo.Jzfls");
            DropForeignKey("dbo.Gcgks", "Gcgk_Id", "dbo.Gcgks");
            DropForeignKey("dbo.Emergencies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Emergencies", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.DocumentStatus", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.DocumentStatus", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.Projects", "CreateUserId", "dbo.Users");
            DropForeignKey("dbo.ContractStatus", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ContractStatus", "Czy_Id", "dbo.Users");
            DropForeignKey("dbo.Contracts", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectContractPayments", "Contract_ProjectId", "dbo.Contracts");
            DropForeignKey("dbo.Contacts", "Contract_ProjectId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "Discount_ProjectId", "dbo.ContractDiscounts");
            DropForeignKey("dbo.ContractDiscounts", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Area_Id", "dbo.Areas");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropForeignKey("dbo.UserPhotoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Xmbhs", new[] {"ProjectId"});
            DropIndex("dbo.Sjdws", new[] {"Project_Id"});
            DropIndex("dbo.ProjectStatus", new[] {"Project_Id"});
            DropIndex("dbo.ProjectStatus", new[] {"Czy_Id"});
            DropIndex("dbo.PaymentAndBillings", new[] {"Project_Id"});
            DropIndex("dbo.PaperStatus", new[] {"Project_Id"});
            DropIndex("dbo.PaperStatus", new[] {"Czy_Id"});
            DropIndex("dbo.Papers", new[] {"Project_Id"});
            DropIndex("dbo.Papers", new[] {"Czy_Id"});
            DropIndex("dbo.OwnerLogins", new[] {"ProjectId"});
            DropIndex("dbo.Htbhs", new[] {"ProjectId"});
            DropIndex("dbo.Gcgks", new[] {"Project_Id"});
            DropIndex("dbo.Gcgks", new[] {"Jzfl_Id"});
            DropIndex("dbo.Gcgks", new[] {"Gcgk_Id"});
            DropIndex("dbo.Emergencies", new[] {"Czy_Id"});
            DropIndex("dbo.Emergencies", new[] {"ProjectId"});
            DropIndex("dbo.DocumentStatus", new[] {"Project_Id"});
            DropIndex("dbo.DocumentStatus", new[] {"Czy_Id"});
            DropIndex("dbo.ContractStatus", new[] {"Project_Id"});
            DropIndex("dbo.ContractStatus", new[] {"Czy_Id"});
            DropIndex("dbo.ProjectContractPayments", new[] {"Contract_ProjectId"});
            DropIndex("dbo.Contacts", new[] {"Contract_ProjectId"});
            DropIndex("dbo.ContractDiscounts", new[] {"ProjectId"});
            DropIndex("dbo.Contracts", new[] {"Discount_ProjectId"});
            DropIndex("dbo.Contracts", new[] {"ProjectId"});
            DropIndex("dbo.Areas", new[] {"CityId"});
            DropIndex("dbo.Projects", new[] {"Area_Id"});
            DropIndex("dbo.Projects", new[] {"CreateUserId"});
            DropIndex("dbo.UserPhotoes", new[] {"UserId"});
            DropIndex("dbo.Users", new[] {"DepartmentId"});
            DropTable("dbo.Xmbhs");
            DropTable("dbo.Sjdws");
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.PaymentAndBillings");
            DropTable("dbo.PaperStatus");
            DropTable("dbo.Papers");
            DropTable("dbo.OwnerLogins");
            DropTable("dbo.Htbhs");
            DropTable("dbo.Jzfls");
            DropTable("dbo.Gcgks");
            DropTable("dbo.Emergencies");
            DropTable("dbo.DocumentStatus");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.ProjectContractPayments");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContractDiscounts");
            DropTable("dbo.Contracts");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
            DropTable("dbo.Projects");
            DropTable("dbo.UserPhotoes");
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
        }
    }
}