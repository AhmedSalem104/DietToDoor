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
    public class MainMenuController : MyController
    {
        // GET: MainMenu
        MainMenuRepository rep = new MainMenuRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("MainMenu", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var Result = rep.GetAll();
            //LoggedUser.CreateActionLog(1021, globalData.UserID, 1, 0, "Main Menu / البنود الرئيسية");

            return View(Result);

        }
        public JsonResult List()
        {
            return Json(db.MainMenu.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                bool flag = LoggedUser.InRole("MainMenu", "create");
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
                bool flag = LoggedUser.InRole("MainMenu", "edit");
                if (flag)
                {
                    var data = db.MainMenu.SingleOrDefault(a => a.Id == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
             
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(MainMenu _MainMenu)
        {
            if (_MainMenu.Id == 0)
            {

                rep.Insert(_MainMenu);
                return Json(Url.Action("Index", "MainMenu"));
            }
            else
            {
                rep.Update(_MainMenu);
                return Json(Url.Action("Index", "MainMenu"));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }

        public JsonResult Delete(int ID)
        {
           
                return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);
           
        }
    }
}