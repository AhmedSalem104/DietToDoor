namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePhoneFromSignForm : DbMigration
    {
        public override void Up()
        {
            DropColumn("GL.SignForm", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("GL.SignForm", "Phone", c => c.String(nullable: false));
        }
    }
}
