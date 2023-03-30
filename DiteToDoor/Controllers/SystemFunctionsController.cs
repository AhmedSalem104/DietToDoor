using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;

using ERPWeb.Models.SecurityRoles;
namespace ERPWeb.Controllers
{
    public class SystemFunctionsController : MyController
    {
        // GET: SystemFunctions

        SystemFunctionsRepository rep = new SystemFunctionsRepository();
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? Id)
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("SystemFunctions", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var q = rep.GetAll();
                return View(q);
        }
        public JsonResult List()
        {
            return Json(db.SystemFunction.Include(a=>a.SystemFunctionParents).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {

                bool flag = LoggedUser.InRole("Employee", "create");
                if (flag)
                {
                    ViewBag.SystemFunctionParentsId = new SelectList(db.SystemFunctionParent.ToList(), "Id", "NameInArabic");

                    return PartialView("ModelCreatePopupPartialView");
                }
                else
                {
                    return PartialView("EnableAccess");
                }
            }
            else
            {
                bool flag = LoggedUser.InRole("Employee", "edit");
                if (flag)
                {
                    var data = db.SystemFunction.SingleOrDefault(a => a.Id == id);

                    ViewBag.SystemFunctionParentsId = new SelectList(db.SystemFunctionParent.ToList(), "Id", "NameInArabic");

                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
               
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(SystemFunction _SystemFunction)
        {
            if (_SystemFunction.Id == 0)
            {
                ViewBag.SystemFunctionParentsId = new SelectList(db.SystemFunctionParent.ToList(), "Id", "NameInArabic");

                rep.Insert(_SystemFunction);
                return Json(Url.Action("Index", "SystemFunctions"));
            }
            else
            {
                ViewBag.SystemFunctionParentsId = new SelectList(db.SystemFunctionParent.ToList(), "Id", "NameInArabic");

                rep.Update(_SystemFunction);
                return Json(Url.Action("Index", "SystemFunctions"));

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
