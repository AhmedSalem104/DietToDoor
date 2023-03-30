namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.CustomerClaasification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("GL.Customers", "Name", c => c.String());
            AddColumn("GL.Customers", "Notes", c => c.String());
            AddColumn("GL.Customers", "CustomerClaasificationId", c => c.Int());
            AddColumn("GL.Customers", "OpenBalnceDept", c => c.Int());
            AddColumn("GL.Customers", "OpenBalnceCridt", c => c.Int());
            AddColumn("GL.Customers", "Address", c => c.String());
            AddColumn("GL.Customers", "Phone", c => c.String());
            AddColumn("GL.Customers", "CustomerPrice", c => c.Int());
            AddColumn("GL.Customers", "CustomerDis", c => c.Int());
            AlterColumn("GL.Customers", "IsCustomer", c => c.Boolean());
            AlterColumn("GL.Customers", "IsDeleted", c => c.Boolean());
            DropColumn("GL.Customers", "Code");
            DropColumn("GL.Customers", "NameEn");
            DropColumn("GL.Customers", "NameAr");
            DropColumn("GL.Customers", "IsActive");
            DropColumn("GL.Customers", "IsCompany");
            DropColumn("GL.Customers", "IsHold");
            DropColumn("GL.Customers", "PoolAccount");
            DropColumn("GL.Customers", "AddressEn");
            DropColumn("GL.Customers", "AddressAr");
            DropColumn("GL.Customers", "PostalCode");
            DropColumn("GL.Customers", "CityId");
            DropColumn("GL.Customers", "ZipCode");
            DropColumn("GL.Customers", "Phone1");
            DropColumn("GL.Customers", "Phone2");
            DropColumn("GL.Customers", "WebSite");
            DropColumn("GL.Customers", "ContactPerson");
            DropColumn("GL.Customers", "ContactPersonMobile");
            DropColumn("GL.Customers", "ContactPersonExt");
            DropColumn("GL.Customers", "ContactPersonemail");
            DropColumn("GL.Customers", "AltContactPerson");
            DropColumn("GL.Customers", "AltContactPersonMobile");
            DropColumn("GL.Customers", "AltContactPersonExt");
            DropColumn("GL.Customers", "AltContactPersonemail");
            DropColumn("GL.Customers", "CustomerClassId");
            DropColumn("GL.Customers", "CreditLimitAmount");
            DropColumn("GL.Customers", "MonthlyCreditLimit");
            DropColumn("GL.Customers", "GeneralLedger");
            DropColumn("GL.Customers", "PriceListId");
            DropColumn("GL.Customers", "CustomField1");
            DropColumn("GL.Customers", "CustomField2");
            DropColumn("GL.Customers", "CustomField3");
            DropColumn("GL.Customers", "CustomField4");
            DropColumn("GL.Customers", "CustomField5");
            DropColumn("GL.Customers", "FesicalYear");
            DropColumn("GL.Customers", "RegDate");
            DropColumn("GL.Customers", "TempCreditLimitAmount");
            DropColumn("GL.Customers", "NotesEn");
            DropColumn("GL.Customers", "NotesAr");
            DropColumn("GL.Customers", "CreatedBy");
            DropColumn("GL.Customers", "CreatedDate");
            DropColumn("GL.Customers", "UpdatedBy");
            DropColumn("GL.Customers", "UpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("GL.Customers", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("GL.Customers", "UpdatedBy", c => c.Int(nullable: false));
            AddColumn("GL.Customers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("GL.Customers", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("GL.Customers", "NotesAr", c => c.String());
            AddColumn("GL.Customers", "NotesEn", c => c.String());
            AddColumn("GL.Customers", "TempCreditLimitAmount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("GL.Customers", "RegDate", c => c.DateTime(nullable: false));
            AddColumn("GL.Customers", "FesicalYear", c => c.Int());
            AddColumn("GL.Customers", "CustomField5", c => c.String());
            AddColumn("GL.Customers", "CustomField4", c => c.String());
            AddColumn("GL.Customers", "CustomField3", c => c.String());
            AddColumn("GL.Customers", "CustomField2", c => c.String());
            AddColumn("GL.Customers", "CustomField1", c => c.String());
            AddColumn("GL.Customers", "PriceListId", c => c.Int());
            AddColumn("GL.Customers", "GeneralLedger", c => c.Int(nullable: false));
            AddColumn("GL.Customers", "MonthlyCreditLimit", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("GL.Customers", "CreditLimitAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("GL.Customers", "CustomerClassId", c => c.Int());
            AddColumn("GL.Customers", "AltContactPersonemail", c => c.String());
            AddColumn("GL.Customers", "AltContactPersonExt", c => c.String());
            AddColumn("GL.Customers", "AltContactPersonMobile", c => c.String());
            AddColumn("GL.Customers", "AltContactPerson", c => c.String());
            AddColumn("GL.Customers", "ContactPersonemail", c => c.String());
            AddColumn("GL.Customers", "ContactPersonExt", c => c.String());
            AddColumn("GL.Customers", "ContactPersonMobile", c => c.String());
            AddColumn("GL.Customers", "ContactPerson", c => c.String());
            AddColumn("GL.Customers", "WebSite", c => c.String());
            AddColumn("GL.Customers", "Phone2", c => c.String());
            AddColumn("GL.Customers", "Phone1", c => c.String());
            AddColumn("GL.Customers", "ZipCode", c => c.String());
            AddColumn("GL.Customers", "CityId", c => c.Int(nullable: false));
            AddColumn("GL.Customers", "PostalCode", c => c.String());
            AddColumn("GL.Customers", "AddressAr", c => c.String());
            AddColumn("GL.Customers", "AddressEn", c => c.String());
            AddColumn("GL.Customers", "PoolAccount", c => c.Int());
            AddColumn("GL.Customers", "IsHold", c => c.Boolean(nullable: false));
            AddColumn("GL.Customers", "IsCompany", c => c.Boolean(nullable: false));
            AddColumn("GL.Customers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("GL.Customers", "NameAr", c => c.String());
            AddColumn("GL.Customers", "NameEn", c => c.String());
            AddColumn("GL.Customers", "Code", c => c.String());
            AlterColumn("GL.Customers", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("GL.Customers", "IsCustomer", c => c.Int(nullable: false));
            DropColumn("GL.Customers", "CustomerDis");
            DropColumn("GL.Customers", "CustomerPrice");
            DropColumn("GL.Customers", "Phone");
            DropColumn("GL.Customers", "Address");
            DropColumn("GL.Customers", "OpenBalnceCridt");
            DropColumn("GL.Customers", "OpenBalnceDept");
            DropColumn("GL.Customers", "CustomerClaasificationId");
            DropColumn("GL.Customers", "Notes");
            DropColumn("GL.Customers", "Name");
            DropTable("GL.CustomerClaasification");
        }
    }
}
