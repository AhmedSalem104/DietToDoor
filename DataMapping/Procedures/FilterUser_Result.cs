using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
    public class FilterUser_Result
    {


        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string ArbDescription { get; set; }
        public int? EmployeeId { get; set; }
        public string EngDescription { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool? AppLanguage { get; set; }
        public string Image { get; set; }
        public bool RememberMe { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime LastLoginDate { get; set; }


        public int GroupId { get; set; }
            public string NameInArabic { get; set; }



        }
    }

