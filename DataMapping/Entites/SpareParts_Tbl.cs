using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Items", Schema = "Gl")]
    public class SpareParts_Tbl
    {
        [Key]
        [Column("ItemId", TypeName = "int")]
        public int SparePartId { get; set; }

        [Column("ItemIdOld", TypeName = "int")]
        public int ItemId_Old { get; set; }


        [Column("ItemCode")]
        public int? SparePartCode { get; set; }

        [Column("ItemName")]
        public string ItemName { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
