using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("Users_Branches", Schema = "Gl")]
    public partial class Users_Branches
    {
        [Key]
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? BranchId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDeleted { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Branches Branch { get; set; }
    }
}
