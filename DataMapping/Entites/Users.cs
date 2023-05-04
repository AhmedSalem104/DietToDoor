using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("Users", Schema = "Gl")]
    public partial class Users
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("ClientId", TypeName = "int")]
        public int? ClientId { get; set; }
        [Required(ErrorMessage = "  الكود مطلوب")]
        [Column("Code", TypeName ="nvarchar(MAX)")]
        public string Code { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column("ArbDescription")]
        public string ArbDescription { get; set; }

        [Required(ErrorMessage = "   اختر الموظف")]
        [Column("EmployeeId", TypeName = "int")]
        public int? EmployeeId { get; set; }

        [Column("EngDescription")]
        public string EngDescription { get; set; }

        [Required(ErrorMessage = "الرقم السري مطلوب")]
        [Column("Password")]
        public string Password { get; set; }

        [Column("IsActive")]
        public bool? IsActive { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Column("AppLanguage")]
        public bool? AppLanguage { get; set; }

        [Column("Image")]
        public string Image { get; set; }
        public bool RememberMe { get; set; }

        [Column("ToDate", TypeName = "datetime")]
        public DateTime ToDate { get; set; }
        [Column("LastLoginDate", TypeName = "datetime")]
        public DateTime LastLoginDate { get; set; }
        
        public virtual Employee Employee { get; set; }
    }
}
