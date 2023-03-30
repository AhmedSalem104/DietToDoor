using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("GroupSecurityRole", Schema = "Gl")]
    public partial class GroupSecurityRole
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("GroupId", TypeName = "int")]
        public int GroupId { get; set; }
     
        [Column("SystemFunctionId", TypeName = "int")]
        public int SystemFunctionId { get; set; }
       
        [Column("CanView")]
        public bool CanView { get; set; }
       
        [Column("CanAdd")]
        public bool CanAdd { get; set; }
       
        [Column("CanEdit")]
        public bool CanEdit { get; set; }
      
        [Column("CanDelete")]
        public bool CanDelete { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual SystemFunction SystemFunction { get; set; }
    }
}
