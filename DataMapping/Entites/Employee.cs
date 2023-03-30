using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("Employee", Schema = "Gl")]
    public class Employee
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("EmpCode")]
        public string EmpCode { get; set; }

        [Column("EmployeeNameAr")]
        public string EmployeeNameAr { get; set; }

        [Column("CreatedBy", TypeName = "int")]
        public int? CreatedBy { get; set; }

        [Column("CreatedDate", TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [Column("UpdatedBy", TypeName = "int")]
        public int? UpdatedBy { get; set; }

        [Column("UpdatedDate", TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }

        [Column("OrganizationId", TypeName = "int")]
        public int? OrganizationId { get; set; }

        [Column("BranchId", TypeName = "int")]
        public int? BranchId { get; set; }

        [Column("EmpNo")]
        public int? EmpNo { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
