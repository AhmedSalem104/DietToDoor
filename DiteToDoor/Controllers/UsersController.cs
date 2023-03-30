using System;
using System.Data.Entity;
using System.IO;
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
    public class UsersController : MyController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        UsersRepository rep = new UsersRepository();
        GlobalData globalData = HelperMethods.globalData;

        // GET: Users
        public ActionResult Index()
        {

            ViewBag.CanAdd = false;
            ViewBag.CanEdit = false;
            ViewBag.CanDelete = false;
            bool flagAdd = LoggedUser.InRole("Users", "create");
            bool flagEdit = LoggedUser.InRole("Users", "edit");
            bool flagDelete = LoggedUser.InRole("Users", "delete");
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
            var user = rep.GetAll();
            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(3, globalData.UserID, 1, 0, "Users / المستخدمين");
            }

            return View(db.Users.Include(a => a.Employee).Where(a => a.IsDeleted == false).ToList());
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.DateNow = DateTime.Now.ToString("dd/MM/yyyy");
            if (id == 0)
            {
                ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic");
                ViewBag.EmployeeId = new SelectList(db.Employee.ToList(), "Id", "EmployeeNameAr");
                return View();
            }
            else
            {
                var data = db.Users.SingleOrDefault(a => a.Id == id);
                ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic");
                ViewBag.EmployeeId = new SelectList(db.Employee.ToList(), "Id", "EmployeeNameAr", data.EmployeeId);

                return View(rep.GetById(id));
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Users _User, HttpPostedFileBase file, int GroupId)
        {
            EmployeeGroups _EmployeeGroups = new EmployeeGroups();
            string path = "";
            if (file != null)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                   Path.GetExtension(file.FileName).ToLower() == ".png" ||
                   Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                   Path.GetExtension(file.FileName).ToLower() == ".Jpeg")
                {
                    path = Path.Combine(Server.MapPath("~/UploadImages"), file.FileName);
                    file.SaveAs(path);
                    _User.Image = "~/UploadImages/" + file.FileName;
                }
            }
            else
            {
                _User.Image = "~/ImgNotFound/images.jpg";
            }
            if (_User.Id == 0)
            {

                rep.Insert(_User);
                _EmployeeGroups.EmployeeId = (int)_User.EmployeeId;
                _EmployeeGroups.UsersId = db.Users.Max(a => a.Id);
                _EmployeeGroups.GroupId = GroupId;
                _EmployeeGroups.IsDeleted = false;
                db.EmployeeGroups.Add(_EmployeeGroups);
                db.SaveChanges();
                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(3, globalData.UserID, 2, db.Users.Max(a => a.Id), "Users / المستخدمين");
                }


                return RedirectToAction(nameof(Index));
            }
            else
            {
                rep.Update(_User);
                LoggedUser.CreateActionLog(3, globalData.UserID, 3, _User.Id, "Users / المستخدمين");

                return RedirectToAction(nameof(Index));

            }

        }


        public ActionResult UpdateUser(int id = 0)
        {
            ViewBag.DateNow = DateTime.Now.ToString("dd/MM/yyyy");


            var data = db.Users.SingleOrDefault(a => a.Id == id);
            var groupPer = db.EmployeeGroups.SingleOrDefault(a => a.UsersId == data.Id).GroupId;
            var group = db.Group.SingleOrDefault(a => a.Id == groupPer);
            ViewBag.GroupId = new SelectList(db.Group, "Id", "NameInArabic", group.Id);

            ViewBag.EmployeeId = new SelectList(db.Employee.ToList(), "Id", "EmployeeNameAr", data.EmployeeId);

            return View(rep.GetById(id));

        }
        [HttpPost]
        public ActionResult UpdateUser(Users _User, HttpPostedFileBase file, int GroupId)
        {
            string path = "";
            if (file != null)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                   Path.GetExtension(file.FileName).ToLower() == ".png" ||
                   Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                   Path.GetExtension(file.FileName).ToLower() == ".Jpeg")
                {
                    path = Path.Combine(Server.MapPath("~/UploadImages"), file.FileName);
                    file.SaveAs(path);
                    _User.Image = "~/UploadImages/" + file.FileName;
                }
            }
            else
            {
                _User.Image = "~/ImgNotFound/images.jpg";
            }


            rep.Update(_User);
            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(3, globalData.UserID, 3, _User.Id, "Users / المستخدمين");
            }

            return RedirectToAction(nameof(Index));



        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }

        public ActionResult Delete(int Id)
        {
            if (globalData.UserID != 0)
            {
                LoggedUser.CreateActionLog(3, globalData.UserID, 4, Id, "Users / المستخدمين");
            }

            var isUserUsed = db.EmployeeGroups.FirstOrDefault(a => a.UsersId == Id);
            //var isUserUsed2 = db.UserSafe.FirstOrDefault(a => a.UsersId == Id);

            if (isUserUsed != null )
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var q = rep.Remove(Id);
                return RedirectToAction(nameof(Index));

            }


        }

    }
}
