using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("SystemFunction", Schema = "Gl")]
    public partial class SystemFunction
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
     
        [Column("NameInArabic")]
        public string NameInArabic { get; set; }

        [Column("NameInEnglish")]
        public string NameInEnglish { get; set; }

        [Column("Controller")]
        public string Controller { get; set; }

        [Column("Action")]
        public string Action { get; set; }
        [Column("AddAction")]
        public string AddAction { get; set; }

        [Column("SystemFunctionParentsId", TypeName = "int")]
        public int? SystemFunctionParentsId { get; set; }

        [Column("Icon")]
        public string Icon { get; set; }
        public virtual SystemFunctionParent SystemFunctionParents { get; set; }

        public virtual ICollection<GroupSecurityRole> GroupSecurityRoles { get; set; }

        public virtual ICollection<EmployeeSecurityRoles> EmployeeSecurityRoles { get; set; }
    }
}
