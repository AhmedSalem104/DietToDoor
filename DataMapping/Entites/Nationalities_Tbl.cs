using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Nationalities", Schema = "Gl")]

    public class Nationalities_Tbl
    {
        [Key]
        [Column("NatId", TypeName = "int")]
        public int NationalId { get; set; }

        [Column("NatId_Old", TypeName = "int")]
        public int NatId_Old { get; set; }


        [Column("NatCode")]
        public int? NatCode { get; set; }

        [Column("NatName")]
        public string NatName { get; set; }

 

        [Column("IsSaudi")]
        public bool? IsSaudi { get; set; }

        [Column("IdNoCheck")]
        public bool? IdNoCheck { get; set; }

        [Column("CountryCode")]
        public string CountryCode { get; set; }

        [Column("EMP_NATIONALITY")]
        public string EMP_NATIONALITY { get; set; }

   

        [Column("Uploaded")]
        public bool? Uploaded { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
