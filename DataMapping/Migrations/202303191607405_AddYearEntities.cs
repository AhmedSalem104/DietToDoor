namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.Years",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearName = c.String(),
                    })
                .PrimaryKey(t => t.YearId);
            
            CreateIndex("GL.EmployeeGroups", "UsersId");
            AddForeignKey("GL.EmployeeGroups", "UsersId", "Gl.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("GL.EmployeeGroups", "UsersId", "Gl.Users");
            DropIndex("GL.EmployeeGroups", new[] { "UsersId" });
            DropTable("GL.Years");
        }
    }
}
