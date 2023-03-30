using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ERPWeb.Models.SecurityRoles;
namespace ERPWEB.Controllers
{
    public class User_BranchesController : MyController
    {
        // GET: User_Branches
        private ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;
        UserBrancheRepository rep = new UserBrancheRepository();
        // GET: UserSafe
        public ActionResult Index()
        {
            ViewBag.CanDelete = false;

            bool flagDelete = LoggedUser.InRole("User_Branches", "delete");

            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            ViewBag.UserId = new SelectList(db.Users.Where(a=>a.IsDeleted==false).ToList(), "Id", "EngDescription");
            //ViewBag.BrancheId = new SelectList(db.Branches.Where(a => a.IsDeleted == false).ToList(), "Id", "BranchesName");
            //return View(db.Users_Branches.Where(a => a.IsDeleted == false).ToList());
            LoggedUser.CreateActionLog(4043, globalData.UserID, 1, 0, "Branches Access / صلاحيات الفروع");

            return View();

        }
        public JsonResult List()
        {
            return Json(db.Users_Branches.Include(a=>a.Users).Include(a=>a.Branch).Where(a => a.IsDeleted == false).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                bool flag = LoggedUser.InRole("User_Branches", "create");
                if (flag)
                {
                    ViewBag.UserNameId = new SelectList(db.Users.Where(a => a.Id == globalData.UserID).ToList(), "Id", "EngDescription");
                    //ViewBag.BrancheId = new SelectList(db.Branches.Where(a => a.IsDeleted == false).ToList(), "Id", "BranchesName");
                    //ViewBag.SafeId = new SelectList(db.Safe.Where(a => a.IsDeleted == false).ToList(), "Id", "SafeName");
                    return PartialView("ModelCreatePopupPartialView");
                }
                else
                {
                    return PartialView("EnableAccess");
                }
            }
            else
            {
                bool flag = LoggedUser.InRole("User_Branches", "edit");
                if (flag)
                {
                    var data = db.Users_Branches.SingleOrDefault(a => a.Id == id);
                    //ViewBag.UserId = new SelectList(db.User.Where(a => a.Id == globalData.UserID), "Id", "EngDescription", data.UserId);
                    //ViewBag.BrancheId = new SelectList(db.Branches.Where(a => a.IsDeleted == false).ToList(), "Id", "BranchesName", data.BranchId);

                    return PartialView("ModelEditPopupPartialView", data);
                }
                else
                {
                    return PartialView("EnableAccess");
                }
               
            }


        }

        [HttpPost]
        public ActionResult AddOrEdit(Users_Branches _UserBranche)
        {
            ViewBag.Errorr = null;

            var BrancheId = db.Users_Branches.Where(a => a.BranchId == _UserBranche.BranchId && a.UsersId == _UserBranche.UsersId && a.IsDeleted == false).FirstOrDefault();

            if (_UserBranche.Id == 0)
            {
                ViewBag.UserNameId = new SelectList(db.Users.Where(a => a.Id == globalData.UserID), "Id", "EngDescription");
                //ViewBag.BrancheId = new SelectList(db.Safe, "Id", "BranchesName");
                if (BrancheId != null)
                {
                    ViewBag.Errorr = "عفوا الخزنة موجودة مسبقا";
                    return PartialView("ModelCreatePopupPartialView");
                }
                else
                {
                    ViewBag.Errorr = null;


                    var usersBranches = db.Users_Branches.ToList();
                    if (usersBranches.Count() == 0)
                    {
                        _UserBranche.IsDefault = true;
                    }
                    else if (usersBranches.Count() > 0 && _UserBranche.IsDefault == true)
                    {
                        var isDefault = db.Users_Branches.Where(a => a.IsDefault == true && a.UsersId == _UserBranche.UsersId && a.IsDeleted == false).FirstOrDefault();
                        if (isDefault != null) { rep.UpdateIsDefault(isDefault); }

                        _UserBranche.IsDefault = true;
                    }
                    else if (usersBranches.Count() > 0 && _UserBranche.IsDefault == false)
                    {
                        var isDefault = db.Users_Branches.Where(a => a.IsDefault == true && a.UsersId == _UserBranche.UsersId && a.IsDeleted == false).FirstOrDefault();
                        if (isDefault == null) { _UserBranche.IsDefault = true; }

                    }
                    _UserBranche.IsDeleted = false;
                    LoggedUser.CreateActionLog(4043, globalData.UserID, 2, db.Users_Branches.Max(a=>a.Id), "Branches Access / صلاحيات الفروع");

                    rep.Insert(_UserBranche);

                }
                return Json(Url.Action("Index", "User_Branches"));


            }

            else if (_UserBranche.Id > 0 && _UserBranche.IsDefault == true)
            {
                //if (SafeId != null)
                //{
                //    ViewBag.Errorr = "عفوا الخزنة موجودة مسبقا";
                //}


                ViewBag.UserNameId = new SelectList(db.Users.Where(a => a.Id == globalData.UserID), "Id", "EngDescription");
                //ViewBag.SafeId = new SelectList(db.Safe, "Id", "SafeName");
                var isDefault = db.Users_Branches.Where(a => a.IsDefault == true && a.UsersId == _UserBranche.UsersId && a.IsDeleted == false).FirstOrDefault();
                if (isDefault != null) { rep.UpdateIsDefault(isDefault); }

                rep.Update(_UserBranche);
                LoggedUser.CreateActionLog(4043, globalData.UserID, 3, _UserBranche.Id, "Branches Access / صلاحيات الفروع");

                return Json(Url.Action("Index", "User_Branches"));

            }

            else
            {
                rep.Update(_UserBranche);
                LoggedUser.CreateActionLog(4043, globalData.UserID, 3, _UserBranche.Id, "Branches Access / صلاحيات الفروع");

                return Json(Url.Action("Index", "User_Branches"));
            }

        }
        public ActionResult Delete(int ID)
        {
            //rep.Delete(ID);
            //var isDefault = db.UserSafe.Where(a => a.IsDefault == false && a.UsersId == ID && a.IsDelete == false).ToList();
            //if(isDefault.Count() == 1)
            //{
            //    rep.Update(isDefault);
            //}
            //return RedirectToAction(nameof(Index));
            LoggedUser.CreateActionLog(4043, globalData.UserID, 5, ID, "Branches Access / صلاحيات الفروع");

            return Json(rep.Delete(ID), JsonRequestBehavior.AllowGet);
            
        }
        //الفلتره باسم المستخدم والفرع معا

        public ActionResult GetUserBrancheFilter(int? UserId = 0, int? BrancheId = 0)
        {
            var _Obj = db.Users_Branches.Include(a=>a.Users).Include(a=>a.Branch).Where(a=>a.IsDeleted==false).ToList();

            if ((UserId == 0 || UserId == null) && (BrancheId == 0 || BrancheId == null)) { }

            if (UserId != 0 && BrancheId != 0)
            {
                _Obj = db.Users_Branches.Include(a => a.Users).Include(a => a.Branch).Where(a=>a.UsersId == UserId && a.BranchId == BrancheId&& a.IsDeleted==false).ToList();

            }
            if (UserId != 0 && (BrancheId == 0 || BrancheId == null))
            {
                _Obj = db.Users_Branches.Include(a => a.Users).Include(a => a.Branch).Where(a => a.UsersId == UserId && a.IsDeleted == false).ToList();

            }

            if (BrancheId != 0 && (UserId == 0 || UserId == null))
            {
                _Obj = db.Users_Branches.Include(a => a.Users).Include(a => a.Branch).Where(a => a.BranchId == BrancheId && a.IsDeleted == false).ToList();

            }


            return Json(_Obj, JsonRequestBehavior.AllowGet);
        }

    }
}