using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DataMapping.Entites
{
    [Table("ServicesTrxD", Schema = "GL")]
    public  class ServicesTrxD
    {

        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }


        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }

        [Column("ServiceTrxId", TypeName = "int")]
        public int? ServiceTrxId { get; set; }

        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }

        [Column("Serial", TypeName = "int")]
        public int? Serial { get; set; }

        [Column("ServiceId", TypeName = "int")]
        public int ServiceId { get; set; }

        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }

    }
}
