using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("Group", Schema = "Gl")]
    public partial class Group
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
       
        [Column("NameInArabic")]
        public string NameInArabic { get; set; }
      
        [Column("NameInEnglish")]
        public string NameInEnglish { get; set; }
        [Column("GroupNo")]
        public int? GroupNo { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
