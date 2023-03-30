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
    public class EmployeeController : MyController
    {
        EmployeeRepository rep = new EmployeeRepository();
        GlobalData globalData = HelperMethods.globalData;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
   
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("Employee", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var Result = rep.GetAll();
            LoggedUser.CreateActionLog(1007, globalData.UserID, 1, 0, "Employee /  الموظفين");

            return View(Result);

        }
        public JsonResult List()
        {
            return Json(db.Employee.Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckEmpNo(int? EmpNo)
        {
            var emp = db.Employee.Where(a => a.EmpNo == EmpNo);
            if (emp.Count() != 0)
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
            int? lastCode = db.Employee.Max(item => (int?)item.Id);
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

                bool flag = LoggedUser.InRole("Employee", "create");
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
                bool flag = LoggedUser.InRole("Employee", "edit");
                if (flag)
                {
                    var data = db.Employee.SingleOrDefault(a => a.Id == id);
                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
              
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee _Employee)
        {
            if (_Employee.Id == 0)
            {

                rep.Insert(_Employee);
                var record = db.Employee.Max(a => a.Id);
                LoggedUser.CreateActionLog(1007, globalData.UserID, 2, record, "Employee /  الموظفين");
                return Json(Url.Action("Index", "Employee"));
            }
            else
            {
                rep.Update(_Employee);
                var record = _Employee.Id;
                LoggedUser.CreateActionLog(1007, globalData.UserID, 3, record, "Employee /  الموظفين");
                return Json(Url.Action("Index", "Employee"));

            }

        }
        public ActionResult Details(int id)
        {

            var q = rep.GetById(id);
            return View(q);
        }

        public JsonResult Delete(int ID)
        {
            LoggedUser.CreateActionLog(1007, globalData.UserID, 5, ID, "Employee /  الموظفين");

            return Json(rep.Remove(ID), JsonRequestBehavior.AllowGet);
          
            
        }

    }
}