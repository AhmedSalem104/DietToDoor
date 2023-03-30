using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Colors", Schema = "Gl")]

    public class Color_Tbl
    {
        [Key]
        [Column("ColorId", TypeName = "int")]
        public int ColorId { get; set; }

        [Column("ColorId_Old", TypeName = "int")]
        public int ColorId_Old { get; set; }


        [Column("ColorCode")]
        public int? ColorCode { get; set; }

        [Column("ColorName")]
        public string ColorName { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
