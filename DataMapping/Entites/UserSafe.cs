using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("SafePermisions", Schema = "GL")]
    public  class UserSafe
    {
        
            [Key]
            [Column("Id", TypeName = "int")]
            public int Id { get; set; }

            [Column("UsersId", TypeName = "int")]
            public int UsersId { get; set; }

            [Column("SafeId", TypeName = "int")]
            public int SafeId { get; set; }
        [Column("BranchesId", TypeName = "int")]
        public int BranchesId { get; set; }
        [Column("IsDefault")]
            public bool? IsDefault { get; set; }
            [Column("IsDelete")]
            public bool? IsDelete { get; set; }

            public virtual Users Users { get; set; }


       

    }
}

