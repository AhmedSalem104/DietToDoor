using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWeb.Models.SecurityRoles;
namespace ERPWeb.Controllers
{
    public class VendorController : MyController
    {
        // GET: Vendor
        VendorRepository rep = new VendorRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;

        public ActionResult Index(int? Id)
        {

            ViewBag.CanAdd = false;
            ViewBag.CanEdit = false;
            ViewBag.CanDelete = false;
            bool flagAdd = LoggedUser.InRole("Vendor", "create");
            bool flagEdit = LoggedUser.InRole("Vendor", "edit");
            bool flagDelete = LoggedUser.InRole("Vendor", "delete");
            if (flagAdd)
            {
                ViewBag.CanAdd = true;
            }
            if (flagEdit)
            {
                ViewBag.CanEdit = true;
            }
            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a=>a.IsDeleted==false).ToList(), "Id", "Name");

            if (Id != null)
            {

                var Result = db.Vendor.Where(a => a.IsDeleted == false && a.Block==false).ToList();
                ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a=>a.IsDeleted==false).ToList(), "Id", "Name", Id);
                LoggedUser.CreateActionLog(3, globalData.UserID, 1, 0, "Vendor/الموردين");

                return View(Result);
            }
            else
            {

                var Vendor = rep.GetAll();
                LoggedUser.CreateActionLog(6, globalData.UserID, 1, 0, "Vendor/الموردين");

                return View(Vendor);
            }


        }

        public bool CheckVendorNo(int? VendorNo)
        {
            var job = db.Vendor.Where(a => a.VendorNo == VendorNo);
            if (job.Count() != 0)
            {
                return false;
            }
            else
            {
                return true;

            }
        }

        internal object GenerateAutoCode()
        {
            int? start = 0;
            int? autoCode;
            int? lastCode = db.Vendor.Max(item => (int?)item.Id);
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
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.autoCode = GenerateAutoCode();
                ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a => a.IsDeleted == false).ToList(), "Id", "Name");

                return View();
            }
            else
            {
                var data = db.Vendor.SingleOrDefault(a => a.Id == id&&a.IsDeleted==false&&a.Block==false);
               
                ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a => a.IsDeleted == false).ToList(), "Id", "Name",data.VendorClassificationId);
                return View(rep.GetById(id));
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Vendor _Vendor)
        {
            Session["msgErrV"] = "";
            if (_Vendor.Id == 0)
            {
                ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a => a.IsDeleted == false).ToList(), "Id", "Name");

                bool check = CheckVendorNo(_Vendor.VendorNo);
                if (check == false)
                {
                    Session["msgErr"] = "رقم المورد هذا موجود مسبقا";
                    return RedirectToAction(nameof(AddOrEdit));
                }
                else
                {
                    rep.Insert(_Vendor);
                    LoggedUser.CreateActionLog(6, globalData.UserID, 2, db.Vendor.Max(a => a.Id), "Vendor/الموردين");

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.VendorClassificationId = new SelectList(db.VendorClassification.Where(a => a.IsDeleted == false).ToList(), "Id", "Name");

                rep.Update(_Vendor);
                LoggedUser.CreateActionLog(6, globalData.UserID, 3, _Vendor.Id, "Vendor/الموردين");

                return RedirectToAction(nameof(Index));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }
        public ActionResult Delete(int id)
        {
            var q = rep.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult PrintDataRDLC()
        {


            //var list = db.GetVendorPrint().Where(a => a.IsDeleted == false).ToList();
            //var userName = globalData.LoginName;
            //var companyName = " بلدية محافظة خليص";


            //Session["UserName"] = userName;
            //Session["CompanyName"] = companyName;



            //string DataSet = "General";
            //string Path = "~/Reporting/RDLC/VendorReport.rdlc";
            //Session["Path"] = Path;
            //Session["DataSet"] = DataSet;
            //Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/VendorForm.aspx");


        }

        //[HttpPost]
        //public ActionResult PrintDataRDLCById(int id)
        //{
        //    var list = db.GetVendorPrint().Where(a => a.IsDeleted == false && a.SupplierId == id);
        //    var userName = globalData.LoginName;
        //    var companyName = " بلدية محافظة خليص";


        //    Session["UserName"] = userName;
        //    Session["CompanyName"] = companyName;

        //    string DataSet = "General";
        //    string Path = "~/Reporting/RDLC/VendorReport.rdlc";
        //    Session["Path"] = Path;
        //    Session["DataSet"] = DataSet;
        //    Session["DataResult"] = list;
        //    return Redirect("~/Reporting/Forms/VendorForm.aspx");


        //}
    }
}