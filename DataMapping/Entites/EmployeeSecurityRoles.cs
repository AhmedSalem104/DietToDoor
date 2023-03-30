using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("EmployeeSecurityRoles", Schema = "GL")]
    public class EmployeeSecurityRoles
    {

        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("EmployeeId", TypeName = "int")]
        public int EmployeeId { get; set; }

        [Column("SystemFunctionId", TypeName = "int")]
        public int SystemFunctionId { get; set; }

        [Column("CanView", TypeName = "bit")]
        public bool CanView { get; set; }

        [Column("CanAdd", TypeName = "bit")]
        public bool CanAdd { get; set; }

        [Column("CanEdit", TypeName = "bit")]
        public bool CanEdit { get; set; }

        [Column("CanDelete", TypeName = "bit")]
        public bool CanDelete { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual SystemFunction SystemFunction { get; set; }
    }
}
