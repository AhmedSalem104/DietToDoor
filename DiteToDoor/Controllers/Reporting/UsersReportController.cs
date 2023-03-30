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
//    public class UsersReportController : MyController
//    {
       
//            ApplicationDbContext db = new ApplicationDbContext();
//            GlobalData globalData = HelperMethods.globalData;
//            private readonly ApplicationDbContext _context = new ApplicationDbContext();
//        // GET: ReceiveRecordReport

//        //public ActionResult FilterDate(DateTime? Start, DateTime? End)
//        //{

//        //    if (Start != null && End != null)
//        //    {

//        //        Session["StartDate"] = Start;
//        //        Session["EndDate"] = End;
//        //        List<FilterReceiveRecordByDate_Result> ListData = db.FilterReceiveRecordByDate(Start, End).Where(a => a.DocDate >= Start && a.DocDate <= End).ToList();
//        //        Session["DataResult"] = ListData;

//        //        return PartialView("FilterDatePartialView", ListData);

//        //    }
//        //    else
//        //    {
//        //        return PartialView("FilterDatePartialView");
//        //    }

//        //}

//        public ActionResult Filter(int? userId, /*DateTime Startdate , DateTime EndDate ,*/ int? groupId, int TypeId)
//        {

//            if (TypeId == 1)
//            {
//                List<FilterUser_Result> listData = null;

//                if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId == null)
//                {
//                    listData = db.FilterUser()/*.Where(a => a.Date >= Startdate & a.Date <= EndDate)*/.ToList();
//                    Session["Result"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => /*a.Date >= Startdate & a.Date <= EndDate &*/ a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => /*a.Date >= Startdate & a.Date <= EndDate &*/ a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a =>/* a.Date >= Startdate & a.Date <= EndDate &*/ a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);

//            }

//            else if (TypeId == 2)
//            {

//                List<FilterUser_Result> listData = null;

//                if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId == null)
//                {
//                    listData = db.FilterUser()/*.Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate)*/.ToList();
//                    Session["Result"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => /*a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate &*/ a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => /*a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate &*/ a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null && */userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => /*a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate &*/ a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);

//            }
//            else
//            {
//                List<FilterUser_Result> listData = null;

//                if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId == null)
//                {
//                    listData = db.FilterUser()/*.Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate)*/.ToList();
//                    Session["Result"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (/*Startdate != null && EndDate != null &&*/ userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);
//            }




//        }


//        public ActionResult FilterBYAll(int? userId , DateTime? Startdate , DateTime? EndDate , int? groupId , int TypeId)
//            {

//            if (TypeId == 1)
//            {
//                List<FilterUser_Result> listData = null;

//                if (Startdate != null && EndDate != null && userId == null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.Date >= Startdate & a.Date <= EndDate).ToList();
//                    Session["Result"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.Date >= Startdate & a.Date <= EndDate & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.Date >= Startdate & a.Date <= EndDate & a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.Date >= Startdate & a.Date <= EndDate & a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);

//            }

//            else if (TypeId == 2) {

//                List<FilterUser_Result> listData = null;

//                if (Startdate != null && EndDate != null && userId == null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate).ToList();
//                    Session["Result"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate & a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate & a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);

//            }
//            else {
//                List<FilterUser_Result> listData = null;

//                if (Startdate != null && EndDate != null && userId == null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a => a.LastLoginDate >= Startdate & a.LastLoginDate <= EndDate).ToList();
//                    Session["Result"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId == null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a =>  a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId == null)
//                {
//                    listData = db.FilterUser().Where(a =>a.UserId == userId).ToList();
//                    Session["DataResult"] = listData;
//                }
//                else if (Startdate != null && EndDate != null && userId != null && groupId != null)
//                {
//                    listData = db.FilterUser().Where(a =>  a.UserId == userId & a.GroupId == groupId).ToList();
//                    Session["DataResult"] = listData;
//                }




//                return PartialView("FilterDatePartialView", listData);
//            }




//        }
//        [HttpPost]
//        public ActionResult PrintDataRDLC()
//        {


//            var userName = globalData.LoginName;
//            var companyName = "بلدية محافظة خليص";


//            Session["UserName"] = userName;
//            Session["CompanyName"] = companyName;
//            var listData = Session["DataResult"];
//            string DataSet = "General";
//            string Path = "~/Reporting/RDLC/FilterUserReport.rdlc";
//            Session["Path"] = Path;
//            Session["DataSet"] = DataSet;
//            Session["DataResult"] = listData;
//            return Redirect("~/Reporting/Forms/UserFilterForm.aspx");


//        }
//        [HttpPost]
//        public ActionResult PrintDataRDLCById(int? Id)
//        { 

//            var Query = db.FilterUser().Where(a => a.UserId == Id).ToList();

//            var userName = globalData.LoginName;
//            var companyName = "بلدية محافظة خليص";


//            Session["UserName"] = userName;
//            Session["CompanyName"] = companyName;

//            string DataSet = "General";
//            string Path = "~/Reporting/RDLC/FilterUserReport.rdlc";
//            Session["Path"] = Path;
//            Session["DataSet"] = DataSet;
//            Session["DataResult"] = Query;
//            return Redirect("~/Reporting/Forms/UserFilterForm.aspx");


//        }
//        public ActionResult Index()
//            {
//                ViewBag.GroupId = new SelectList(db.Group.Where(a => a.IsDeleted == false), "Id", "NameInArabic").ToList();
//                ViewBag.UserId = new SelectList(db.Users.Where(a => a.IsDeleted == false), "Id", "ArbDescription").ToList();
//            if (globalData.UserID != 0)
//            {
//                LoggedUser.CreateActionLog(8, globalData.UserID,2, 0, "UsersReport /تقرير المستخدمين ");
//            }
//                return View();
//            }

//        }
//    }
