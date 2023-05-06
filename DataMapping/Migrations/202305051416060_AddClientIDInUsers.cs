namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientIDInUsers : DbMigration
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
            
            CreateTable(
                "GL.FollowUp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        CurrentWeight = c.Decimal(precision: 18, scale: 2),
                        CurrentCenterOfCircumference = c.Decimal(precision: 18, scale: 2),
                        Notes = c.String(),
                        Attachment = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("Gl.Users", "ClientId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Gl.Users", "ClientId");
            DropTable("Gl.Subject");
            DropTable("GL.FollowUp");
            DropTable("GL.ContactUs");
        }
    }
}
