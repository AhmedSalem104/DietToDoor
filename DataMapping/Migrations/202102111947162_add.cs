namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CounrytId = c.Int(),
                        NameEn = c.String(nullable: false),
                        NameAr = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GL.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "Gl.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(nullable: false),
                        NameAr = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(nullable: false),
                        NameAr = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.StorePlace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(nullable: false),
                        NameAr = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.Uint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameEn = c.String(nullable: false),
                        NameAr = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("GL.Branches", "Notes", c => c.String());
            CreateIndex("GL.Branches", "OrganizationId");
            AddForeignKey("GL.Branches", "OrganizationId", "Gl.Organizations", "Id");
            DropColumn("GL.Branches", "Code");
            DropColumn("GL.Branches", "CountryId");
            DropColumn("GL.Branches", "Phone1");
            DropColumn("GL.Branches", "Email");
            DropColumn("GL.Branches", "ManagerId");
            DropColumn("GL.Branches", "IsActive");
            DropColumn("GL.Branches", "AddressEn");
            DropColumn("GL.Branches", "AddressAr");
            DropColumn("GL.Branches", "NotesEn");
            DropColumn("GL.Branches", "NotesAr");
            DropColumn("GL.Branches", "CreatedBy");
            DropColumn("GL.Branches", "CreatedDate");
            DropColumn("GL.Branches", "UpdatedBy");
            DropColumn("GL.Branches", "UpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("GL.Branches", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("GL.Branches", "UpdatedBy", c => c.Int(nullable: false));
            AddColumn("GL.Branches", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("GL.Branches", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("GL.Branches", "NotesAr", c => c.String());
            AddColumn("GL.Branches", "NotesEn", c => c.String());
            AddColumn("GL.Branches", "AddressAr", c => c.String());
            AddColumn("GL.Branches", "AddressEn", c => c.String());
            AddColumn("GL.Branches", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("GL.Branches", "ManagerId", c => c.Int(nullable: false));
            AddColumn("GL.Branches", "Email", c => c.String());
            AddColumn("GL.Branches", "Phone1", c => c.String());
            AddColumn("GL.Branches", "CountryId", c => c.Int());
            AddColumn("GL.Branches", "Code", c => c.String());
            DropForeignKey("GL.City", "Country_Id", "GL.Country");
            DropForeignKey("GL.Branches", "OrganizationId", "Gl.Organizations");
            DropIndex("GL.City", new[] { "Country_Id" });
            DropIndex("GL.Branches", new[] { "OrganizationId" });
            DropColumn("GL.Branches", "Notes");
            DropTable("GL.Uint");
            DropTable("GL.StorePlace");
            DropTable("GL.Jobs");
            DropTable("Gl.Department");
            DropTable("GL.City");
        }
    }
}
