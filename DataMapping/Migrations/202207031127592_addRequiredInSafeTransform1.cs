namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredInSafeTransform1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("GL.AssetClassifcation", "AssetClassifcationNamedAr", c => c.String(nullable: false));
            AlterColumn("GL.AssetClassifcation", "AssetClassifcationNamedEn", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("GL.AssetClassifcation", "AssetClassifcationNamedEn", c => c.String());
            AlterColumn("GL.AssetClassifcation", "AssetClassifcationNamedAr", c => c.String());
        }
    }
}
