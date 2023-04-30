namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjecttabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Gl.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectCode = c.Int(),
                        SubjectName = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropTable("Gl.Subject");
        }
    }
}
