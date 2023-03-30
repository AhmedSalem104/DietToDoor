using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.Models
{
    public class GlobalData
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }
        public string Image { get; set; }
        public int CompanyID { get; set; }
        public int BranchId { get; set; }
        public int WorkingDate { get; set; }
        public int DefaultLanguage { get; set; }
        public bool PDefaultLanguage { get; set; }
        public string UserDescription { get; set; }
        public string EngDescription { get; set; }
        public string CompanyDescription { get; set; }
        public int iStartWorkingDate { get; set; }
        public int iEndWorkingDate { get; set; }
        public bool IsCurrentYear { get; set; }
        public short YearStatus { get; set; }
        public string EmpName { get; set; }
        public string BrancheName { get; set; }
        public string LoginName { get; set; }
        public string CompanyName { get; set; }
        public bool RememberMe { get; set; }
        public int? Year { get; set; }

        //public string CompanyManager { get; set; }


        //public string MaintananceManager { get; set; }


        //public string MovementManager { get; set; }

    }
}