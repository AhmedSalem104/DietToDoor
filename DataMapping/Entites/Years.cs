using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("Years", Schema = "GL")]

    public class Years
    {
        [Key]
        [Column("YearId", TypeName = "int")]
        public int YearId { get; set; }
        [Column("YearName")]
        public string YearName { get; set; }
    }
}
