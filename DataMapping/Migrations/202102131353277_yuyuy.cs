namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yuyuy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.Itemgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        VendorClassificationId = c.Int(),
                        IsVendorAndCustomer = c.Boolean(),
                        Block = c.Boolean(),
                        OpenBalnceDept = c.Int(),
                        OpenBalnceCridt = c.Int(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        RecordNumber = c.Int(),
                        TaxRecord = c.Int(),
                        Fax = c.String(),
                        Email = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.VendorClassification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.VendorClassification");
            DropTable("GL.Vendor");
            DropTable("GL.Itemgroups");
            DropTable("GL.ItemCategories");
        }
    }
}
