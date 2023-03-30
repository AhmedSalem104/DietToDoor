using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("GasolineTypes", Schema = "GL")]
    public class GasolineTypes
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("GasolineTypeName")]
        public string GasolineTypeName { get; set; }
        
    }
}
