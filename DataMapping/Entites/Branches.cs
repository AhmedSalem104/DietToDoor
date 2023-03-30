using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("Branches",Schema ="GL")]
    public class Branches
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }


        [Column("BrancheId_Old", TypeName = "int")]
        public int BrancheId_Old { get; set; }

        [Column("BranchesName")]
        public string BranchesName { get; set; }

        //[Column("OrganizationId", TypeName = "int")]
        //public int? OrganizationId { get; set; }

        [Column("Notes", TypeName = "nvarchar(MAX)")]
        public string Notes{ get; set; }
        [Column("BrnacheNo")]
        public int? BrnacheNo { get; set; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }
        //public virtual Organizations Organization { get; set; }

        //public static explicit operator Branches(List<Branches> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
