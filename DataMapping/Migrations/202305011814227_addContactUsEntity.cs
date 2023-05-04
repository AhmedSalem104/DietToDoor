namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactUsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Satissfied = c.Boolean(nullable: false),
                        NotSatissfied = c.Boolean(nullable: false),
                        SubjectId = c.Int(),
                        Comment = c.String(),
                        Attachment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.ContactUs");
        }
    }
}
