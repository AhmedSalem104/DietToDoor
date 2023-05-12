namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGetClientsInfoProc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Gl.ServiceOpinion",
                c => new
                    {
                        ServiceOpinionId = c.Int(nullable: false, identity: true),
                        ServiceOpinionCode = c.Int(),
                        ServiceOpinionName = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceOpinionId);
            
            AddColumn("GL.ContactUs", "ClientId", c => c.Int());
            AddColumn("GL.ContactUs", "ServiceOpinionId", c => c.Int());
            AddColumn("GL.ContactUs", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("GL.ContactUs", "Date");
            DropColumn("GL.ContactUs", "ServiceOpinionId");
            DropColumn("GL.ContactUs", "ClientId");
            DropTable("Gl.ServiceOpinion");
        }
    }
}
