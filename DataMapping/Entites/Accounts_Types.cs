using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataMapping.Entites
{
    [Table("Accounts_Types", Schema = "GL")]
  public  class Accounts_Types
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column("Accounts_TypesName")]
        public string Accounts_TypesName { get; set; }
    }
}
