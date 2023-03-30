using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("Users_Groups", Schema = "Gl")]
    public partial class Users_Groups
    {
        [Key]
        public int UGroup_Id { get; set; }
        public string UGroup_Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
