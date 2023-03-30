namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddfff : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.Customers", "Block", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("GL.Customers", "Block");
        }
    }
}
