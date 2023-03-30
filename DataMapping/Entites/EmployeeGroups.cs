using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("EmployeeGroups", Schema = "GL")]
    public class EmployeeGroups
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("GroupId", TypeName = "int")]
        public int GroupId { get; set; }

        [Column("EmployeeId", TypeName = "int")]
        public int EmployeeId { get; set; }

        [Column("UsersId", TypeName = "int")]
        public int UsersId { get; set; }

        [Column("IsDeleted", TypeName = "bit")]
        public Nullable<bool> IsDeleted { get; set; }

        public virtual Group Group { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual Users Users { get; set; }
    }
}
