namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientIdInContactUsEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.ContactUs", "ClientId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("GL.ContactUs", "ClientId");
        }
    }
}
