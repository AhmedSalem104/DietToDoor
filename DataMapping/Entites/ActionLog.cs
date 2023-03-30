using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("ActionLog", Schema = "GL")]
    public class ActionLog
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("UsersId", TypeName = "int")]
        public int? UsersId { get; set; }
        [Column("SystemFunctionId", TypeName = "int")]
        public int? SystemFunctionId { get; set; }


        [Column("CreatedDate", TypeName = "datetime")]
        public System.DateTime CreatedDate { get; set; }

        [Column("IP")]
        public string IP { get; set; }

        [Column("ActionId", TypeName = "int")]
        public int? ActionId { get; set; }

        [Column("RecordId", TypeName = "int")]
        public int? RecordId { get; set; }
        [Column("FunctionName")]
        public string FunctionName { get; set; }
        public virtual SystemFunction SystemFunction { get; set; }
        public virtual Users Users { get; set; }

    }
}
