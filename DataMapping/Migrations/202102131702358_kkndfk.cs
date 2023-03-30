namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkndfk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Gl.Itemspecification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gl.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(),
                        CityId = c.Int(),
                        EmpId = c.Int(),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                        Branches_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GL.Branches", t => t.Branches_Id)
                .ForeignKey("GL.City", t => t.CityId)
                .ForeignKey("Gl.Employee", t => t.Employee_Id)
                .Index(t => t.CityId)
                .Index(t => t.Branches_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Gl.Store", "Employee_Id", "Gl.Employee");
            DropForeignKey("Gl.Store", "CityId", "GL.City");
            DropForeignKey("Gl.Store", "Branches_Id", "GL.Branches");
            DropIndex("Gl.Store", new[] { "Employee_Id" });
            DropIndex("Gl.Store", new[] { "Branches_Id" });
            DropIndex("Gl.Store", new[] { "CityId" });
            DropTable("Gl.Store");
            DropTable("Gl.Itemspecification");
        }
    }
}
