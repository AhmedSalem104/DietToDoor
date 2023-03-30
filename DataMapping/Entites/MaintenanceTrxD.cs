using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("MaintenanceTrxD", Schema = "GL")]

    public class MaintenanceTrxD
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("TrxType")]
        public int? TrxType { get; set; }

        [Column("Year")]
        public int? Year { get; set; }

        [Column("Serial")]
        public int? Serial { get; set; }

        [Column("LineNo")]
        public int? LineNo { get; set; }
        [Column("ItemId")]
        public int? ItemId { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }
    }
}
