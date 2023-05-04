using System;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataMapping.Entites;
using ERPWeb.Models;
using ERPWeb.Models.SecurityRoles;

namespace Maintanence.Controllers
{
   


    public class NationalitiesController : MyController
    {
        // GET: Bank
        NationalitiesRepository rep = new NationalitiesRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;



        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("Nationalities", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(1004, globalData.UserID, 1, 0, "Nationalities /  الجنسيات");

            }

            var Result = rep.GetAll();
            return View();

        }
        public JsonResult List()
        {
            return Json(db.Nationalities_Tbl.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckBankNo(int? ColorId)
        {
            var CarsTypes = db.Nationalities_Tbl.Where(a => a.NationalId == ColorId);
            if (CarsTypes.Count() != 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }

        internal object GenerateAutoCode()
        {
            int? start = 0;
            int? autoCode;
            int? lastCode = db.Nationalities_Tbl.Where(a=>a.IsDeleted ==false).Max(item => (int?)item.NatCode);
            if (lastCode != 0 && lastCode != null)
            {
                start = lastCode;
                autoCode = (start + 1);
            }
            else
            {
                start = 0;
            }
            autoCode = (start + 1);
            return autoCode;
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.autoCode = GenerateAutoCode();
            if (id == 0)
            {
                bool flag = LoggedUser.InRole("Nationalities", "create");
                if (flag)
                {
                    return PartialView("ModelCreatePopupPartialView");
                }
                else
                {
                    return PartialView("EnableAccess");
                }

            }
            else
            {
                bool flag = LoggedUser.InRole("Nationalities", "edit");
                if (flag)
                {
                    var data = db.Nationalities_Tbl.SingleOrDefault(a => a.NationalId == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }

            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Nationalities_Tbl _color)
        {
            if (_color.NationalId == 0)
            {
            
                rep.Insert(_color);
                var record = db.Nationalities_Tbl.Max(a => a.NatCode);
                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(1004, globalData.UserID, 2, record, "Nationalities / الجنسيات");

                }
                return Json(Url.Action("Index", "Bank"));
            }
            else
            {

                rep.Update(_color);
                var record = _color.NationalId;
                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(1004, globalData.UserID, 3, record, "Nationalities / الجنسيات");

                }
                return Json(Url.Action("Index", "Bank"));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }

        public JsonResult Delete(int ID)
        {
            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(1004, globalData.UserID, 4, ID, "Nationalities / الجنسيات");

            }



            //var DriverNo = db.Drivers.FirstOrDefault(a => a.NatId == ID).DriverNo;
            ////var IsUnitUse = db.MoneyTRX.FirstOrDefault(a => a.UnitNo == UnitNo);
            //if (DriverNo != null)
            //{
                return Json(false, JsonRequestBehavior.AllowGet);

            //}
            //else
            //{
                return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);

            //}






        }


        [HttpPost]
        public ActionResult PrintDataRDLC()
        {


            var list = db.Nationalities_Tbl.Where(a => a.IsDeleted == false).ToList();
            var userName = globalData.LoginName;
            var companyName = " بلدية محافظة خليص";


            Session["UserName"] = userName;
            Session["CompanyName"] = companyName;



            string DataSet = "General";
            string Path = "~/Reporting/RDLC/NationalitiesReport.rdlc";
            Session["Path"] = Path;
            Session["DataSet"] = DataSet;
            Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/NationalitiesForm.aspx");


        }

        [HttpPost]
        public ActionResult PrintDataRDLCById(int id)
        {
            var list = db.Nationalities_Tbl.Where(a => a.IsDeleted == false && a.NationalId == id);
            var userName = globalData.LoginName;
            var companyName = " بلدية محافظة خليص";


            Session["UserName"] = userName;
            Session["CompanyName"] = companyName;

            string DataSet = "General";
            string Path = "~/Reporting/RDLC/NationalitiesReport.rdlc";
            Session["Path"] = Path;
            Session["DataSet"] = DataSet;
            Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/NationalitiesForm.aspx");


        }
    }

}