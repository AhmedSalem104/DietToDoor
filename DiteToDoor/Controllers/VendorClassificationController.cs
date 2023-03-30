using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWeb.Models.SecurityRoles;
namespace StoreSystem.Controllers
{
    public class VendorClassificationController : MyController
    {
        // GET: VendorClassification
        VendorClassificationRepository rep = new VendorClassificationRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;

        // GET: Branch
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("VendorClassification", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var q = rep.GetAll();
            LoggedUser.CreateActionLog(7, globalData.UserID, 1, 0, "Vendor Classification / تصنيف الموردين");

            return View();
        }

        public JsonResult List()
        {
            return Json(db.VendorClassification.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckVendorClaasificationNo(int? VendorClaasificationNo)
        {
            var job = db.VendorClassification.Where(a => a.VendorClaasificationNo == VendorClaasificationNo);
            if (job.Count() != 0)
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
            int? lastCode = db.VendorClassification.Max(item => (int?)item.Id);
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

                bool flag = LoggedUser.InRole("VendorClassification", "create");
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
                bool flag = LoggedUser.InRole("VendorClassification", "edit");
                if (flag)
                {
                    var data = db.VendorClassification.SingleOrDefault(a => a.Id == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
               
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(VendorClassification _VendorClassification)
        {
            if (_VendorClassification.Id == 0)
            {
                rep.Insert(_VendorClassification);
                LoggedUser.CreateActionLog(7, globalData.UserID, 2, db.VendorClassification.Max(a=>a.Id), "Vendor Classification / تصنيف الموردين");

                return Json(Url.Action("Index", "VendorClassification"));
            }
            else
            {

                rep.Update(_VendorClassification);
                LoggedUser.CreateActionLog(7, globalData.UserID, 1, _VendorClassification.Id, "Vendor Classification / تصنيف الموردين");

                return Json(Url.Action("Index", "VendorClassification"));

            }



        }
        public ActionResult details(int id)
        {
             var q = rep.GetById(id);
            return View(q);
        }

        public JsonResult Delete(int ID)
        {

            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(7, globalData.UserID, 5, ID, "Vendor Classification / تصنيف الموردين");
            }
            //var VendorCalssificationNo = db.Suppliers_Tbl.FirstOrDefault(a => a.SupplierId == ID);
            ////var IsUnitUse = db.MoneyTRX.FirstOrDefault(a => a.UnitNo == UnitNo);
            //if (VendorCalssificationNo != null)
            //{
                return Json(false, JsonRequestBehavior.AllowGet);

            //}
            //else
            //{
            //    return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);

            //}

            //return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public ActionResult PrintDataRDLC()
        {


            //var list = db.Color_Tbl.Where(a => a.IsDeleted == false).ToList();
            //var userName = globalData.LoginName;
            //var companyName = " بلدية محافظة خليص";


            //Session["UserName"] = userName;
            //Session["CompanyName"] = companyName;



            //string DataSet = "General";
            //string Path = "~/Reporting/RDLC/VendorClassificationReport.rdlc";
            //Session["Path"] = Path;
            //Session["DataSet"] = DataSet;
            //Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/VendorClassificationForm.aspx");


        }

        [HttpPost]
        public ActionResult PrintDataRDLCById(int id)
        {
            var list = db.VendorClassification.Where(a => a.IsDeleted == false && a.Id == id);
            var userName = globalData.LoginName;
            var companyName = " بلدية محافظة خليص";


            Session["UserName"] = userName;
            Session["CompanyName"] = companyName;

            string DataSet = "General";
            string Path = "~/Reporting/RDLC/VendorClassificationReport.rdlc";
            Session["Path"] = Path;
            Session["DataSet"] = DataSet;
            Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/VendorClassificationForm.aspx");


        }
    }
}