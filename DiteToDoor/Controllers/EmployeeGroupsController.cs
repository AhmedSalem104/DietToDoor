using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using ERPWeb.Models.SecurityRoles;
namespace ERPWeb.Controllers
{
    public class EmployeeGroupsController : MyController
    {
        EmployeeGroupsRepository rep = new EmployeeGroupsRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;


        // GET: EmployeeGroups
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("EmployeeGroups", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }

            ViewBag.GroupsId = new SelectList(db.Group.ToList(), "Id", "NameInArabic");
            LoggedUser.CreateActionLog(1027, globalData.UserID, 1, 0, "Employee Groups /  صلاحيات المستخدمين - مجموعات");

            return View();
        }

        public JsonResult List()
        {
            return Json(db.EmployeeGroups.Include(a=>a.Employee).Include(a=>a.Group).Include(a=>a.Users).Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                bool flag = LoggedUser.InRole("EmployeeGroups", "create");
                if (flag)
                {
                    ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeNameAr");
                    ViewBag.UsersId = new SelectList(db.Users, "Id", "Code");

                    ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic");
                    return PartialView("ModelCreatePopupPartialView");
                }
                else
                {
                    return PartialView("EnableAccess");
                }
              
            }
            else
            {
                bool flag = LoggedUser.InRole("EmployeeGroups", "edit");
                if (flag)
                {
                    var data = db.EmployeeGroups.SingleOrDefault(a => a.Id == id);
                    //ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeNameAr", data.EmployeeId);
                    //ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic",data.GroupId);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
              
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeGroups _EmployeeGroups)
        {
            if (_EmployeeGroups.Id == 0)
            {
                ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeNameAr");
                ViewBag.UsersId = new SelectList(db.Users, "Id", "Code");
                ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic");
                var empId = db.Users.SingleOrDefault(a => a.Id == _EmployeeGroups.UsersId).EmployeeId;
                _EmployeeGroups.EmployeeId = (int)empId;
                
                var Exist = db.EmployeeGroups.SingleOrDefault(a => a.UsersId == _EmployeeGroups.UsersId && a.IsDeleted == false);
                if (Exist != null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    rep.Insert(_EmployeeGroups);
                    var record = db.EmployeeGroups.Max(a => a.Id);
                    LoggedUser.CreateActionLog(1027, globalData.UserID, 2, record, "Employee Groups /  صلاحيات المستخدمين - مجموعات");
                    return Json(Url.Action("Index", "EmployeeGroups"));
                }
            }
            else
            {
                ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "EmployeeNameAr");
                ViewBag.UsersId = new SelectList(db.Users, "Id", "Code");
                ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic");
                var empId = db.Users.SingleOrDefault(a => a.Id == _EmployeeGroups.UsersId).EmployeeId;
                _EmployeeGroups.EmployeeId = (int)empId;
                rep.Update(_EmployeeGroups);
                var record = _EmployeeGroups.Id;
                LoggedUser.CreateActionLog(1027, globalData.UserID, 3, record, "Employee Groups /  صلاحيات المستخدمين - مجموعات");
                return Json(Url.Action("Index", "EmployeeGroups"));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }
        //public ActionResult Delete(int id)
        //{
        //    var q = rep.Remove(id);
        //    return RedirectToAction(nameof(Index));
        //}
        public JsonResult Delete(int ID)
        {
            LoggedUser.CreateActionLog(1027, globalData.UserID, 5, ID, "Employee Groups /  صلاحيات المستخدمين - مجموعات");

            return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);
            
        }

        //جلب اسم المستخدم
        public JsonResult GetUserName(int ID = 0)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var UsersList = "";
                db.Configuration.ProxyCreationEnabled = false;
                if (ID == null || ID == 0)
                {
                    UsersList = "";
                }
                else
                {
                     UsersList = db.Users.FirstOrDefault(a => a.Id == ID).ArbDescription;
                   
                }
                return Json(UsersList, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetByGroupFilter(int? GroupId = 0)
        {
            var _Obj = db.EmployeeGroups.Include(a => a.Employee).Include(a => a.Group).Include(a => a.Users).Where(a => a.IsDeleted == false).ToList();
            if (GroupId == 0 || GroupId == null)
            {

            }
            else
            {
                _Obj = db.EmployeeGroups.Include(a => a.Employee).Include(a => a.Group).Include(a => a.Users).Where(a => a.IsDeleted == false && a.GroupId == GroupId).ToList();
            }

            return Json(_Obj, JsonRequestBehavior.AllowGet);
        }
    }
}
