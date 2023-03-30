namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVegetables : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.FoodFrequency", "Vegetables", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("GL.FoodFrequency", "Vegetables");
        }
    }
}
