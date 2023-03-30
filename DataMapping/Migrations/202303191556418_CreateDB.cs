namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.ActionLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(),
                        SystemFunctionId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        IP = c.String(),
                        ActionId = c.Int(),
                        RecordId = c.Int(),
                        FunctionName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.SystemFunction", t => t.SystemFunctionId)
                .ForeignKey("Gl.Users", t => t.UsersId)
                .Index(t => t.UsersId)
                .Index(t => t.SystemFunctionId);
            
            CreateTable(
                "Gl.SystemFunction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameInArabic = c.String(),
                        NameInEnglish = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        AddAction = c.String(),
                        SystemFunctionParentsId = c.Int(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.SystemFunctionParent", t => t.SystemFunctionParentsId)
                .Index(t => t.SystemFunctionParentsId);
            
            CreateTable(
                "GL.EmployeeSecurityRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SystemFunctionId = c.Int(nullable: false),
                        CanView = c.Boolean(nullable: false),
                        CanAdd = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("Gl.SystemFunction", t => t.SystemFunctionId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SystemFunctionId);
            
            CreateTable(
                "Gl.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpCode = c.String(),
                        EmployeeNameAr = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(storeType: "date"),
                        OrganizationId = c.Int(),
                        BranchId = c.Int(),
                        EmpNo = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.GroupSecurityRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SystemFunctionId = c.Int(nullable: false),
                        CanView = c.Boolean(nullable: false),
                        CanAdd = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("Gl.SystemFunction", t => t.SystemFunctionId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SystemFunctionId);
            
            CreateTable(
                "Gl.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameInArabic = c.String(),
                        NameInEnglish = c.String(),
                        GroupNo = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.SystemFunctionParent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainMenuId = c.Int(),
                        NameInArabic = c.String(),
                        NameInEnglish = c.String(),
                        SecondLevelInArabic = c.String(),
                        SecondLevelInEnglish = c.String(),
                        HasParent = c.Boolean(),
                        Icons = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ArbDescription = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        EngDescription = c.String(),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        AppLanguage = c.Boolean(),
                        Image = c.String(),
                        RememberMe = c.Boolean(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "GL.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionNameAr = c.String(),
                        ActionNameEn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.ActivationTbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginCount = c.String(),
                        licenceType = c.Int(),
                        serialKey = c.String(),
                        productMac = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.CompanyInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        CompanyManager = c.String(),
                        MaintenanceManager = c.String(),
                        MovementManager = c.String(),
                        Employee1 = c.String(),
                        Employee2 = c.String(),
                        SupervisorManager = c.String(),
                        CompanyAddress = c.String(),
                        CountryId = c.Int(),
                        GovernatesId = c.Int(),
                        CityId = c.Int(),
                        YearId = c.Int(),
                        CurrenciesId = c.Int(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        PostalCode = c.String(),
                        TaxNumber = c.Int(),
                        Image = c.String(),
                        FiscalYearStartDate = c.DateTime(nullable: false),
                        FiscalYearEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.EmployeeGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gl.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("Gl.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "Gl.InvoicesSettings",
                c => new
                    {
                        InvoicesSettingId = c.Int(nullable: false, identity: true),
                        YearId = c.Int(),
                        Conditions = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.InvoicesSettingId);
            
            CreateTable(
                "GL.MainMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        Icons = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.Nationalities",
                c => new
                    {
                        NatId = c.Int(nullable: false, identity: true),
                        NatId_Old = c.Int(nullable: false),
                        NatCode = c.Int(),
                        NatName = c.String(),
                        IsSaudi = c.Boolean(),
                        IdNoCheck = c.Boolean(),
                        CountryCode = c.String(),
                        EMP_NATIONALITY = c.String(),
                        Uploaded = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.NatId);
            
            CreateTable(
                "Gl.Users_Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(),
                        BranchId = c.Int(),
                        IsDefault = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GL.Branches", t => t.BranchId)
                .ForeignKey("Gl.Users", t => t.UsersId)
                .Index(t => t.UsersId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "GL.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrancheId_Old = c.Int(nullable: false),
                        BranchesName = c.String(),
                        Notes = c.String(),
                        BrnacheNo = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.Users_Groups",
                c => new
                    {
                        UGroup_Id = c.Int(nullable: false, identity: true),
                        UGroup_Name = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.UGroup_Id);
            
            CreateTable(
                "GL.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierId_Old = c.Int(nullable: false),
                        SupplierName = c.String(nullable: false),
                        Notes = c.String(),
                        VendorClassificationId = c.Int(nullable: false),
                        IsVendorAndCustomer = c.Boolean(),
                        Block = c.Boolean(),
                        OpenBalnceDept = c.Int(),
                        OpenBalnceCridt = c.Int(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        RecordNumber = c.Int(),
                        TaxRecord = c.Int(),
                        Fax = c.String(),
                        Email = c.String(),
                        VendorNo = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "GL.VendorClassification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(),
                        VendorClaasificationNo = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Gl.Users_Branches", "UsersId", "Gl.Users");
            DropForeignKey("Gl.Users_Branches", "BranchId", "GL.Branches");
            DropForeignKey("GL.EmployeeGroups", "GroupId", "Gl.Group");
            DropForeignKey("GL.EmployeeGroups", "EmployeeId", "Gl.Employee");
            DropForeignKey("GL.ActionLog", "UsersId", "Gl.Users");
            DropForeignKey("Gl.Users", "EmployeeId", "Gl.Employee");
            DropForeignKey("GL.ActionLog", "SystemFunctionId", "Gl.SystemFunction");
            DropForeignKey("Gl.SystemFunction", "SystemFunctionParentsId", "Gl.SystemFunctionParent");
            DropForeignKey("Gl.GroupSecurityRole", "SystemFunctionId", "Gl.SystemFunction");
            DropForeignKey("Gl.GroupSecurityRole", "GroupId", "Gl.Group");
            DropForeignKey("GL.EmployeeSecurityRoles", "SystemFunctionId", "Gl.SystemFunction");
            DropForeignKey("GL.EmployeeSecurityRoles", "EmployeeId", "Gl.Employee");
            DropIndex("Gl.Users_Branches", new[] { "BranchId" });
            DropIndex("Gl.Users_Branches", new[] { "UsersId" });
            DropIndex("GL.EmployeeGroups", new[] { "EmployeeId" });
            DropIndex("GL.EmployeeGroups", new[] { "GroupId" });
            DropIndex("Gl.Users", new[] { "EmployeeId" });
            DropIndex("Gl.GroupSecurityRole", new[] { "SystemFunctionId" });
            DropIndex("Gl.GroupSecurityRole", new[] { "GroupId" });
            DropIndex("GL.EmployeeSecurityRoles", new[] { "SystemFunctionId" });
            DropIndex("GL.EmployeeSecurityRoles", new[] { "EmployeeId" });
            DropIndex("Gl.SystemFunction", new[] { "SystemFunctionParentsId" });
            DropIndex("GL.ActionLog", new[] { "SystemFunctionId" });
            DropIndex("GL.ActionLog", new[] { "UsersId" });
            DropTable("GL.VendorClassification");
            DropTable("GL.Suppliers");
            DropTable("Gl.Users_Groups");
            DropTable("GL.Branches");
            DropTable("Gl.Users_Branches");
            DropTable("Gl.Nationalities");
            DropTable("GL.MainMenu");
            DropTable("Gl.InvoicesSettings");
            DropTable("GL.EmployeeGroups");
            DropTable("GL.CompanyInfo");
            DropTable("GL.ActivationTbl");
            DropTable("GL.Actions");
            DropTable("Gl.Users");
            DropTable("Gl.SystemFunctionParent");
            DropTable("Gl.Group");
            DropTable("Gl.GroupSecurityRole");
            DropTable("Gl.Employee");
            DropTable("GL.EmployeeSecurityRoles");
            DropTable("Gl.SystemFunction");
            DropTable("GL.ActionLog");
        }
    }
}
