using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("AssetClassifcation", Schema = "GL")]
    public  class AssetClassifcation
    {
        [Key]
        [Column("AssetClassifcationId", TypeName = "int")]
        public int AssetClassifcationId { get; set; }

       
       

        [Column("AssetClassifcationNo")]
        public string AssetClassifcationNo { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        [Column("AssetClassifcationNamedAr")]
        public string AssetClassifcationNamedAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        [Column("AssetClassifcationNamedEn")]
        public string AssetClassifcationNamedEn { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Column("Depreciable")]
        public bool Depreciable { get; set; }
        [Column("LifeCycle", TypeName = "int")]
        public int? LifeCycle { get; set; }

        [Column("LifeCycleType")]
        public string LifeCycleType { get; set; }

        [Column("AssetAccount")]
        public int? AssetAccount { get; set; }

        [Column("DepreciationEcpenseAccount")]
        public int? DepreciationEcpenseAccount { get; set; }

        [Column("AccumulatedDepreciationAccount")]
        public int? AccumulatedDepreciationAccount { get; set; }
        [Column("DepreciationType")]
        public bool DepreciationType { get; set; }
    }
}
