using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("CompanyInfo", Schema = "GL")]
    public class CompanyInfo
    {

        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("CompanyName", TypeName = "nvarchar(MAX)")]
        public string CompanyName { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("CompanyManager", TypeName = "nvarchar(MAX)")]
        public string CompanyManager { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("MaintenanceManager", TypeName = "nvarchar(MAX)")]
        public string MaintananceManager { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("MovementManager", TypeName = "nvarchar(MAX)")]
        public string MovementManager { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("Employee1", TypeName = "nvarchar(MAX)")]
        public string Employee1 { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("Employee2", TypeName = "nvarchar(MAX)")]
        public string Employee2 { get; set; }

        [Column("SupervisorManager", TypeName = "nvarchar(MAX)")]
        public string SupervisorManager { get; set; }
        


        [Column("CompanyAddress")]
        public string CompanyAddress { get; set; }

        //[Required(ErrorMessage = "   اختر الدولة")]
        [Column("CountryId", TypeName = "int")]
        public int? CountryId { get; set; }

        //[Column("GovernatesId", TypeName = "int")]
        public int? GovernatesId { get; set; }

        [Column("CityId", TypeName = "int")]
        public int? CityId { get; set; }

        [Column("YearId", TypeName = "int")]
        public int? YearId { get; set; }

        [Column("CurrenciesId", TypeName = "int")]
        public int? CurrenciesId { get; set; }
        [Column("Mobile")]
        public string Mobile { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Column("Email")]
        public string Email { get; set; }
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        

        [Column("TaxNumber", TypeName = "int")]
        public int? TaxNumber { get; set; }
        [Column("Image")]
        public string Image { get; set; }
        [Column("FiscalYearStartDate", TypeName = "datetime")]
        public DateTime FiscalYearStartDate { get; set; }

        [Column("FiscalYearEndDate", TypeName = "datetime")]
        public DateTime FiscalYearEndDate { get; set; }

      

    }
}
