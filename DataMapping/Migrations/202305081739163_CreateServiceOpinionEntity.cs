namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateServiceOpinionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.ContactUs", "ServiceOpinionId", c => c.Int());
            AddColumn("GL.ContactUs", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("GL.ContactUs", "Date");
            DropColumn("GL.ContactUs", "ServiceOpinionId");
        }
    }
}
