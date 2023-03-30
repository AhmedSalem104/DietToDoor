using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWEB.Models
{
    public class SystemSettingsModel
    {
        public  CompanyInfo CompanyInfo { get; set; }
        public InvoicesSettings InvoicesSettings { get; set; }
        //public InvoicesSettings Qutations { get; set; }
        //public InvoicesSettings PurchaseOrders { get; set; }
        //public InvoicesSettings Purchases { get; set; }
        //public InvoicesSettings Docs { get; set; }

    }
}