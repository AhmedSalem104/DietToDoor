using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class LangController : MyController
    {
        // GET: Lang
        GlobalData globalData = HelperMethods.globalData;
      
        public ActionResult ChangeLanguage(string lang, string url)
        {
            new LanguageMang().SetLanguage(lang);
            return Redirect(url);
        }
    }
}