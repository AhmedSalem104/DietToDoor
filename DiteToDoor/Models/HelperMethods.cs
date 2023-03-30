using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.Models
{
    public class HelperMethods
    {
        public static GlobalData globalData
        {
            get
            {
                if (HttpContext.Current.Session["globalData"] == null) return new GlobalData();
                return (GlobalData)HttpContext.Current.Session["globalData"];
            }
            set { HttpContext.Current.Session["globalData"] = value; }
        }
    }
}