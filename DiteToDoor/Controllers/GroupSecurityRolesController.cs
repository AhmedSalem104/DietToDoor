using DataMapping.Entites;
using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class GroupSecurityRolesController : MyController
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: GroupSecurityRoles
        public ActionResult Index()
        {
            ViewBag.menuLevel2 = db.SystemFunctionParent.ToList();
            var Groups = db.Group.ToList();
            return View(Groups);
        }

        [HttpGet]
        public ActionResult GetMenuRoles(int Id)
        {
            var GroupSecurityRoles = db.GroupSecurityRole.Where(x => x.SystemFunction.SystemFunctionParentsId == Id).ToList();
            var SystemFunctions = db.SystemFunction.Where(a => a.SystemFunctionParentsId == Id).ToList();

            if (SystemFunctions.Count() >= GroupSecurityRoles.Count())
            {
                foreach (var item in SystemFunctions)
                {
                    if (GroupSecurityRoles.Where(x => x.SystemFunctionId == item.Id).Count() <= 0)
                    {
                        GroupSecurityRole newGroupSecurityRole = new GroupSecurityRole()
                        {
                            GroupId = Id,
                            SystemFunctionId = item.Id,
                            CanView = false,
                            CanAdd = false,
                            CanEdit = false,
                            CanDelete = false,
                        };

                        db.GroupSecurityRole.Add(newGroupSecurityRole);
                        db.Entry(newGroupSecurityRole).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                }
            }

            return PartialView(GroupSecurityRoles.Where(x => x.SystemFunction.SystemFunctionParentsId == Id));
        }


        [HttpGet]
        public ActionResult GetGroupRoles(int Id)
        {
            var GroupSecurityRoles = db.GroupSecurityRole.Where(x => x.GroupId == Id);
            var SystemFunctions = db.SystemFunction.ToList();

            if (SystemFunctions.Count() > GroupSecurityRoles.Count())
            {
                foreach (var item in SystemFunctions)
                {
                    if (GroupSecurityRoles.Where(x => x.SystemFunctionId == item.Id).Count() <= 0)
                    {
                        GroupSecurityRole newGroupSecurityRole = new GroupSecurityRole()
                        {
                            GroupId = Id,
                            SystemFunctionId = item.Id,
                            CanView = false,
                            CanAdd = false,
                            CanEdit = false,
                            CanDelete = false,
                        };

                        db.GroupSecurityRole.Add(newGroupSecurityRole);
                        db.Entry(newGroupSecurityRole).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                }
            }

            return PartialView(GroupSecurityRoles.Where(x => x.GroupId == Id));
        }

        [HttpPost]
        public ActionResult GetGroupRoles(int GroupIds, int[] CanView, int[] CanAdd, int[] CanEdit, int[] CanDelete)
        {
            var collection = db.GroupSecurityRole.Where(x => x.GroupId == GroupIds).ToList();

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
            return RedirectToAction("Index");
        }

    }
}