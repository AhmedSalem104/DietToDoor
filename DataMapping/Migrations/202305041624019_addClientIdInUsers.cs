namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientIdInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("Gl.Users", "ClientId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Gl.Users", "ClientId");
        }
    }
}
