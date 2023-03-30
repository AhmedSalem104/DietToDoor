using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("ActivationTbl", Schema = "GL")]
    public class ActivationTbl
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("LoginCount")]
        public string LoginCount { get; set; }

        [Column("licenceType", TypeName = "int")]
        public int? licenceType { get; set; }


        [Column("serialKey")]
        public string serialKey { get; set; }

        [Column("productMac")]
        public string productMac { get; set; }
    }
}
