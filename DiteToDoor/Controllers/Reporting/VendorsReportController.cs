//using DataMapping.Entites;
//using DataMapping.Procedures;
//using ERPWeb.Models;
//using ERPWeb.Models.SecurityRoles;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;


//namespace Maintanence.Controllers.Reporting
//{
   
//        // GET: CarsReport
//        public class VendorsReportController : MyController
//        {
//            ApplicationDbContext db = new ApplicationDbContext();
//            GlobalData globalData = HelperMethods.globalData;
//            private readonly ApplicationDbContext _context = new ApplicationDbContext();
//            // GET: ReceiveRecordReport

//            //public ActionResult FilterDate(DateTime? Start, DateTime? End)
//            //{

//            //    if (Start != null && End != null)
//            //    {

//            //        Session["StartDate"] = Start;
//            //        Session["EndDate"] = End;
//            //        List<FilterReceiveRecordByDate_Result> ListData = db.FilterReceiveRecordByDate(Start, End).Where(a => a.DocDate >= Start && a.DocDate <= End).ToList();
//            //        Session["DataResult"] = ListData;

//            //        return PartialView("FilterDatePartialView", ListData);

//            //    }
//            //    else
//            //    {
//            //        return PartialView("FilterDatePartialView");
//            //    }

//            //}


//            public ActionResult Filter( int? VendorId)
//            {

              
//                var VendorName = db.GetVendorPrint().Where(a => a.IsDeleted == false && a.SupplierId == VendorId).SingleOrDefault()?.SupplierName;

//                if (VendorName == null)
//                {
//                    VendorName = "إختيار الكل";
//                }
               
//                Session["VendorId"] = VendorId;
           

//                List<GetVendorPrint_Result> listData = null;

//                if (VendorId == null)
//                {
//                    listData = db.GetVendorPrint().ToList();
//                    Session["Result"] = listData;
//                }
//                else if ( VendorId != null )
//                {
//                    listData = db.GetVendorPrint().Where(a=>a.SupplierId == VendorId).ToList();
//                    Session["Result"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);



//            }
//            [HttpPost]
//            public ActionResult PrintDataRDLC()
//            {


//                var userName = globalData.LoginName;
//                var companyName = "بلدية محافظة خليص";


//                Session["UserName"] = userName;
//                Session["CompanyName"] = companyName;
//                var listData = Session["Result"];
//                string DataSet = "General";
//                string Path = "~/Reporting/RDLC/VendorReport.rdlc";
//                Session["Path"] = Path;
//                Session["DataSet"] = DataSet;
//                Session["DataResult"] = listData;
//                return Redirect("~/Reporting/Forms/VendorForm.aspx");


//            }
//        [HttpPost]
//        public ActionResult PrintDataRDLCById(int? Id)
//        {

//            var Query = db.Vendor.Where(a => a.Id == Id).ToList();

//            var userName = globalData.LoginName;
//            var companyName = "بلدية محافظة خليص";


//            Session["UserName"] = userName;
//            Session["CompanyName"] = companyName;
         
//            string DataSet = "General";
//            string Path = "~/Reporting/RDLC/VendorReport.rdlc";
//            Session["Path"] = Path;
//            Session["DataSet"] = DataSet;
//            Session["DataResult"] = Query;
//            return Redirect("~/Reporting/Forms/VendorForm.aspx");


//        }
//        public ActionResult Index()
//            {
//                ViewBag.VendorId = new SelectList(db.Vendor.Where(a => a.IsDeleted == false), "Id", "SupplierName").ToList();
//                LoggedUser.CreateActionLog(17, globalData.UserID, 1, 0, "VendorsReport /تقرير الموردين ");

//                return View();
//            }

//        }
//    }
