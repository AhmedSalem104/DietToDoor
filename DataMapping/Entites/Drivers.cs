using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataMapping.Entites
{
    [Table("Drivers", Schema = "GL")]
    public class Drivers
    {
        [Key]
        [Column("DriverID", TypeName = "int")]
        public int Id { get; set; }

        [Column("DriverID_Old", TypeName = "int")]
        public int DriverID_Old { get; set; }

        [Column("DriverNo", TypeName = "int")]
        public int? DriverNo { get; set; }
        [Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("DriverName", TypeName = "nvarchar(MAX)")]
        public string DriverName { get; set; }


        [Column("NatId", TypeName = "int")]
        public int? NatId { get; set; }

        [Column("BranchId", TypeName = "int")]
        public int? BranchId { get; set; }

        [Column("LicenseTypeId", TypeName = "int")]
        public int? LicenseTypeId { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }
        [Column("LicenseNo")]
        public string LicenseNo { get; set; }
        [Column("LicensePlace")]
        public string LicensePlace { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }
        [Column("MobileCCode")]
        public string MobileCode { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
      
        [Column("LicenseReleaseDate", TypeName = "datetime")]
        public DateTime? LicenseReleaseDate { get; set; }

        [Column("LicenseReleaseDateH", TypeName = "datetime")]
        public DateTime? LicenseReleaseDateH { get; set; }
        [Column("LicenseEndDate", TypeName = "datetime")]
        public DateTime? LicenseEndDate { get; set; }

        [Column("LicenseEndDateH", TypeName = "datetime")]
        public DateTime? LicenseEndDateH { get; set; }
       
    }
}
