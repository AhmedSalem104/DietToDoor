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
    public class GroupController : MyController
    {
        // GET: Group
        GroupRepository rep = new GroupRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("Group", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var Result = rep.GetAll();
            LoggedUser.CreateActionLog(1, globalData.UserID, 1, 0, "Group/  المجموعات");

            return View(Result);

        }
        public JsonResult List()
        {
            return Json(db.Group.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckGroupNo(int? GroupNo)
        {
            var cur = db.Group.Where(a => a.GroupNo == GroupNo);
            if (cur.Count() != 0)
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
            int? lastCode = db.Group.Max(item => (int?)item.Id);
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
            if (id == 0)
            {
                bool flag = LoggedUser.InRole("Group", "create");
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
                bool flag = LoggedUser.InRole("Group", "edit");
                if (flag)
                {
                    var data = db.Group.SingleOrDefault(a => a.Id == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
              
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Group _Group)
        {
            if (_Group.Id == 0)
            {

                rep.Insert(_Group);
                var record = db.Group.Max(a => a.Id);
                LoggedUser.CreateActionLog(3003, globalData.UserID, 2, record, "Group/  المجموعات");
                return Json(Url.Action("Index", "Group"));
            }
            else
            {
                rep.Update(_Group);
                var record = _Group.Id;
                LoggedUser.CreateActionLog(3003, globalData.UserID, 3, record, "Group/  المجموعات");
                return Json(Url.Action("Index", "Group"));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }

        public JsonResult Delete(int ID)
        {
            LoggedUser.CreateActionLog(3003, globalData.UserID, 5, ID, "Group/  المجموعات");

            return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);
            
        }
    }
}