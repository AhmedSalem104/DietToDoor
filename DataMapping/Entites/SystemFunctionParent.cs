
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("SystemFunctionParent", Schema = "Gl")]
    public partial class SystemFunctionParent
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("MainMenuId", TypeName = "int")]
        public int? MainMenuId { get; set; }

        [Column("NameInArabic")]
        public string NameInArabic { get; set; }

        [Column("NameInEnglish")]
        public string NameInEnglish { get; set; }

        [Column("SecondLevelInArabic")]
        public string SecondLevelInArabic { get; set; }

        [Column("SecondLevelInEnglish")]
        public string SecondLevelInEnglish { get; set; }

        [Column("HasParent")]
        public bool? HasParent { get; set; }

        [Column("Icons")]
        public string Icons { get; set; }    
    }
}
