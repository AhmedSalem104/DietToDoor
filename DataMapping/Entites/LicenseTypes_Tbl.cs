using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("LicenseTypes", Schema = "GL")]

    public class LicenseTypes_Tbl
    {
        [Key]
        [Column("LicenseTypeId", TypeName = "int")]
        public int Id { get; set; }

        [Column("LicenseTypeId_Old", TypeName = "int")]
        public int LicenseTypeId_Old { get; set; }

        [Column("LicenseTypeName")]
        public string LicenseTypeNameName { get; set; }

        [Column("LicenseTypeNo")]
        public int? LicenseTypeNo { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
