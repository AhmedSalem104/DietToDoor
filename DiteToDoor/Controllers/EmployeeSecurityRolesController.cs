using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataMapping.Entites;
using ERPWeb.Models;
using ERPWeb.Models.SecurityRoles;


namespace ERPWeb.Controllers
{
    public class EmployeeSecurityRolesController : MyController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;

        // GET: EmployeeSecurityRoles
        public ActionResult Index()
        {
            var Employee = db.Employee.ToList();
            LoggedUser.CreateActionLog(1028, globalData.UserID, 1, 0, "Employee Security Roles /  صلاحيات المستخدمين - شاشات");

            return View(Employee);
        }

        [HttpGet]
        public ActionResult GetEmployeeRoles(int Id)
        {
            var EmployeeSecurityRoles = db.EmployeeSecurityRoles.Where(x => x.EmployeeId == Id).ToList();
            var SystemFunctions = db.SystemFunction.ToList();

            if (SystemFunctions.Count() > EmployeeSecurityRoles.Count())
            {
                foreach (var item in SystemFunctions)
                {
                    if (EmployeeSecurityRoles.Where(x => x.SystemFunctionId == item.Id).Count() <= 0)
                    {
                        EmployeeSecurityRoles newEmployeeecurityRole = new EmployeeSecurityRoles()
                        {
                            EmployeeId = Id,
                            SystemFunctionId = item.Id,
                            CanView = false,
                            CanAdd = false,
                            CanEdit = false,
                            CanDelete = false,
                        };

                        db.EmployeeSecurityRoles.Add(newEmployeeecurityRole);
                        db.Entry(newEmployeeecurityRole).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                }
            }

            return PartialView(EmployeeSecurityRoles.Where(x => x.EmployeeId == Id));
        }

        [HttpPost]
        public ActionResult GetEmployeeRoles(int EmployeeIds, int[] CanView, int[] CanAdd, int[] CanEdit, int[] CanDelete)
        {
            var collection = db.EmployeeSecurityRoles.Where(x => x.EmployeeId == EmployeeIds).ToList();

            foreach (var item in collection)
            {
                if (CanView != null && CanView.Contains(item.Id))
                    item.CanView = true;
                else
                    item.CanView = false;


                if (CanAdd != null && CanAdd.Contains(item.Id))
                    item.CanAdd = true;
                else
                    item.CanAdd = false;


                if (CanEdit != null && CanEdit.Contains(item.Id))
                    item.CanEdit = true;
                else
                    item.CanEdit = false;


                if (CanDelete != null && CanDelete.Contains(item.Id))
                    item.CanDelete = true;
                else
                    item.CanDelete = false;
            }

            db.SaveChanges();
            var record = db.EmployeeSecurityRoles.Max(a => a.Id);
            LoggedUser.CreateActionLog(1028, globalData.UserID, 2, record, "Employee Security Roles /  صلاحيات المستخدمين - شاشات");
            return RedirectToAction("Index");
        }
    }
}
