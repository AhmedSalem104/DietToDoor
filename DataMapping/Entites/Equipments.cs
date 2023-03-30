using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("Equipments", Schema = "GL")]
   public class Equipments
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("CarNo", TypeName = "int")]
        public int? CarNo { get; set; }
        [Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("ChassisNo", TypeName = "nvarchar(MAX)")]
        public string ChassisNo { get; set; }


        [Column("PanelNo")]
        public string PanelNo { get; set; }

        [Column("DriverID", TypeName = "int")]
        public int? DriverID { get; set; }

        [Column("GovernatesId", TypeName = "int")]
        public int? GovernatesId { get; set; }

        [Column("ModelNo", TypeName = "int")]
        public int? ModelNo { get; set; }

        [Column("CarTypeId", TypeName = "int")]
        public int? CarTypeId { get; set; }
        [Column("ColorId")]
        public int? ColorId { get; set; }
        [Column("Horsepower")]
        public int? Horsepower { get; set; }
        [Column("CarLicenseNo")]
        public string CarLicenseNo { get; set; }
        [Column("SupplierId")]
        public int? SupplierId { get; set; }

        [Column("ConditionId")]
        public int? ConditionId { get; set; }

        [Column("Available")]
        public bool? Available { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
        [Column("MonthlyFuel")]
        public decimal? MonthlyFuel { get; set; }

        [Column("ReplaceOil")]
        public int? ReplaceOil { get; set; }
        [Column("ReplaceOilLimit")]
        public int? ReplaceOilLimit { get; set; }
        [Column("WarrantyPeriod", TypeName = "int")]
        public int? WarrantyPeriod { get; set; }

        [Column("PeriodType", TypeName = "int")]
        public int? PeriodType { get; set; }

        [Column("RegisterTypeId", TypeName = "int")]
        public int? RegisterTypeId { get; set; }
        [Column("ReleasePlace")]
        public string ReleasePlace { get; set; }
        [Column("L1")]
        public string L1 { get; set; }
        [Column("L2")]
        public string L2 { get; set; }
        [Column("L3")]
        public string L3 { get; set; }

        [Column("N1", TypeName = "int")]
        public int? N1 { get; set; }

        [Column("N2", TypeName = "int")]
        public int? N2 { get; set; }
        [Column("N3", TypeName = "int")]
        public int? N3 { get; set; }
        [Column("N4", TypeName = "int")]
        public int? N4 { get; set; }

        [Column("VTypeId", TypeName = "int")]
        public int? VTypeId { get; set; }
        [Column("SeatsNo", TypeName = "int")]
        public int? SeatsNo { get; set; }
        [Column("InsurNo")]
        public string InsurNo { get; set; }

        [Column("InsurCompany")]
        public string InsurCompany { get; set; }
        [Column("ReleaseDate", TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }

        [Column("ReleaseDateH", TypeName = "datetime")]
        public DateTime? ReleaseDateH { get; set; }
        [Column("EndDate", TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [Column("EndDateH", TypeName = "datetime")]
        public DateTime? EndDateH { get; set; }
        [Column("PurchaseDate", TypeName = "datetime")]
        public DateTime? PurchaseDate { get; set; }

        [Column("PurchaseDateH", TypeName = "datetime")]
        public DateTime? PurchaseDateH { get; set; }

        [Column("ServiceDate", TypeName = "datetime")]
        public DateTime? ServiceDate { get; set; }

        [Column("ServiceDateH", TypeName = "datetime")]
        public DateTime? ServiceDateH { get; set; }
        [Column("ServiceOutDate", TypeName = "datetime")]
        public DateTime? ServiceOutDate { get; set; }

        [Column("ServiceOutDateH", TypeName = "datetime")]
        public DateTime? ServiceOutDateH { get; set; }

        [Column("InsurIssueDate", TypeName = "datetime")]
        public DateTime? InsurIssueDate { get; set; }

        [Column("InsurIssueDateH", TypeName = "datetime")]
        public DateTime? InsurIssueDateH { get; set; }
        [Column("InsurEndDate", TypeName = "datetime")]
        public DateTime? InsurEndDate { get; set; }

        [Column("InsurEndDateH", TypeName = "datetime")]
        public DateTime? InsurEndDateH { get; set; }

        [Column("CheckEndDate", TypeName = "datetime")]
        public DateTime? CheckEndDate { get; set; }

        [Column("CheckEndDateH", TypeName = "datetime")]
        public DateTime? CheckEndDateH { get; set; }
    }
}
