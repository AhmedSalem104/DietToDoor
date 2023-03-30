using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("StationTRXTypes", Schema = "GL")]
    public class StoreTRXTypes
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("NameAr")]
        public string NameAr { get; set; }

        [Column("NameEn")]
        public string NameEn { get; set; }

        [Column("TRXTypes", TypeName = "int")]
        public int TRXTypes { get; set; }

    }
}
