using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("Days", Schema = "GL")]
   public class Days
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("NameEn")]
        public string NameEn { get; set; }

        //[Column("OrganizationId", TypeName = "int")]
        //public int? OrganizationId { get; set; }

        [Column("NameAr")]
        public string NameAr { get; set; }
    }
}
