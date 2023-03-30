using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{

    [Table("Services", Schema = "Gl")]
    public  class Service_Tbl
    {
        [Key]
        [Column("ServiceId", TypeName = "int")]
        public int ServiceId { get; set; }

        [Column("ServiceId_Old", TypeName = "int")]
        public int ServiceId_Old { get; set; }


        [Column("ServiceCode")]
        public int? ServiceCode { get; set; }

        [Column("ServiceName")]
        public string ServiceName { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
