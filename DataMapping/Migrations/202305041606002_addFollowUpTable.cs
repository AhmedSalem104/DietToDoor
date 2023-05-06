namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFollowUpTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("GL.FollowUp");
        }
    }
}
