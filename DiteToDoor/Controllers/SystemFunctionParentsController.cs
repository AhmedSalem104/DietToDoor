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
    public class SystemFunctionParentsController : MyController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        SystemFunctionParentRepository rep = new SystemFunctionParentRepository();
        // GET: SystemFunctionParents

        public ActionResult Index(int? Id)
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("SystemFunctionParents", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var q = rep.GetAll();
            return View(q);
        }
        public JsonResult List()
        {
            return Json(db.SystemFunctionParent.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {

                bool flag = LoggedUser.InRole("SystemFunctionParents", "create");
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
                bool flag = LoggedUser.InRole("SystemFunctionParents", "edit");
                if (flag)
                {
                    var data = db.SystemFunctionParent.SingleOrDefault(a => a.Id == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
               
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(SystemFunctionParent _SystemFunctionParent)
        {
            if (_SystemFunctionParent.Id == 0)
            {               
                rep.Insert(_SystemFunctionParent);
                return Json(Url.Action("Index", "SystemFunctionParents"));
            }
            else
            {

                rep.Update(_SystemFunctionParent);
                return Json(Url.Action("Index", "SystemFunctionParents"));

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
