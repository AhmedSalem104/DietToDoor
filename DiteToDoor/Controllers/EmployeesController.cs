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
    public class EmployeesController : MyController
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        //EmployeesRepository Repo = new EmployeesRepository();
        //GlobalData globalData = HelperMethods.globalData;
        //// GET: Employees
        //public ActionResult Index()
        //{

        //    ViewBag.CanAdd = false;
        //    ViewBag.CanEdit = false;
        //    ViewBag.CanDelete = false;
        //    bool flagAdd = LoggedUser.InRole("Employees", "create");
        //    bool flagEdit = LoggedUser.InRole("Employees", "edit");
        //    bool flagDelete = LoggedUser.InRole("Employees", "delete");
        //    if (flagAdd)
        //    {
        //        ViewBag.CanAdd = true;
        //    }
        //    if (flagEdit)
        //    {
        //        ViewBag.CanEdit = true;
        //    }
        //    if (flagDelete)
        //    {
        //        ViewBag.CanDelete = true;
        //    }
        //    ViewBag.EmployeesId = new SelectList(db.Employees.ToList(), "Id", "Id");
        //    ViewBag.EmployeesName = new SelectList(db.Employees.ToList(), "Id", "EmployeeNameAr");
        //    ViewBag.DepartmentId = new SelectList(db.Department.ToList(), "Id", "DepartmentName");

        //    ViewBag.JobTitle = new SelectList(db.JobTitles.ToList(), "Id", "JobTitle");
        //    List<SelectListItem> ActiveOrNot = new List<SelectListItem>();
        //    ActiveOrNot.Add(new SelectListItem() { Text = "نشط", Value = "true" });
        //    ActiveOrNot.Add(new SelectListItem() { Text = "غير نشط", Value = "false" });
        //    SelectList ActiveOrNott = new SelectList(ActiveOrNot, "Value", "Text");
        //    ViewBag.ActiveOrNott = ActiveOrNott;
        //    LoggedUser.CreateActionLog(2031, globalData.UserID, 1, 0, "Employees/الموظفين");

        //    return View(db.Employees.Where(a => a.IsDeleted == false).ToList());
        //}

        //public JsonResult List()
        //{
        //    return Json(db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).ToList().OrderByDescending(a => a.Id), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult AddEmployees()
        //{
        //    ViewBag.autoDate = DateTime.Now.ToString("yyyy/MM/dd");
            
        //    ViewBag.DefultBranch = globalData.BranchId;

        //    return View();
        //}

        //[HttpPost]
        //public JsonResult AddEmployees(Employees Employees)
        //{
        //    bool status = true;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            Employees.BranchId = globalData.BranchId;
        //            //Employees.CompanyId = globalData.CompanyID;
        //            Employees.CreatedBy = globalData.UserID;
        //            Employees.UpdatedBy = globalData.UserID;
        //            Employees.CreatedDate = DateTime.Now;
        //            Employees.UpdatedDate = DateTime.Now;
        //            Employees.IsEmpActive = true;
        //            Employees.IsTransformSalaryToBankAccount = false;
        //            Repo.Insert(Employees);
        //            LoggedUser.CreateActionLog(5070, globalData.UserID, 2, db.Employees.Max(a => a.Id), "Employees/الموظفين");

        //            var q = Session["ID"] = db.Employees.Max(x => x.Id);
        //            if (db.SaveChanges() > 0)
        //            {
        //                return new JsonResult { Data = new { status = status, message = "order add successfully" } };
        //            }
        //        }
        //        catch (Exception ex)
        //        {
                    
        //            throw;
        //        }

        //        return new JsonResult { Data = new { status = status, message = "order add successfully" } };
        //    }
        //}

        //public ActionResult UpdateEmployees(int id)
        //{
        //    var obj = Repo.GetById(id);
        //    ViewBag.autoDate = obj.CreatedDate;
        //    //ViewBag.autoCode = obj.SalesINVNo;
        //    ViewBag.DefultBranch = obj.BranchId;
        //    Employees Emps = new Employees();

        //    Emps.Id = obj.Id;
        //    Emps.Gender = obj.Gender;
        //    Emps.EmployeeNameAr = obj.EmployeeNameAr;
        //    Emps.BirthDate = obj.BirthDate;
        //    Emps.MilitaryStatus = obj.MilitaryStatus;
        //    Emps.CountryId = obj.CountryId;
        //    Emps.NationalityId = obj.NationalityId;
        //    Emps.BranchId = obj.BranchId;
        //    Emps.Email = obj.Email;
        //    Emps.PhoneNumber = obj.PhoneNumber;
        //    Emps.UrgentPhoneNumber = obj.UrgentPhoneNumber;
        //    Emps.Address = obj.Address;
        //    Emps.WorkEmailAddress = obj.WorkEmailAddress;
        //    Emps.WorkPhoneNumber = obj.WorkPhoneNumber;
        //    Emps.BankId = obj.BankId;
        //    Emps.AccountBankNo = obj.AccountBankNo;
        //    Emps.JobNumber = obj.JobNumber;
        //    Emps.JoinDate = obj.JoinDate;
           
        //    Emps.WorkTable = obj.WorkTable;
        //    Emps.JobTitlesId = obj.JobTitlesId;
        //    Emps.DepartmentId = obj.DepartmentId;
        //    Emps.QualificationId = obj.QualificationId;
        //    Emps.QualificationDescription = obj.QualificationDescription;
        //    Emps.FirstSalaryDate = obj.FirstSalaryDate;

        //    Emps.LastSalaryDate = obj.LastSalaryDate;
        //    Emps.PaymentCycle = obj.PaymentCycle;
        //    Emps.SalaryValue = obj.SalaryValue;
        //    Emps.EmployeeNameEn = obj.EmployeeNameEn;
        //    Emps.CreatedBy = obj.CreatedBy;
        //    Emps.CreatedDate = obj.CreatedDate;
        //    Emps.UpdatedBy = obj.UpdatedBy;
        //    Emps.UpdatedDate = obj.UpdatedDate;
        //    Emps.IsDeleted = false;
        //    Session["IDD"] = obj.Id;
        //    return View(Emps);
        //}

        //[HttpPost]
        //public JsonResult UpdateEmployees(Employees Emps)
        //{
        //    bool status = true;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            Emps.Id = Convert.ToInt32(Session["IDD"]);
        //            Emps.BranchId = globalData.BranchId;
                   
        //            Emps.CreatedBy = globalData.UserID;
        //            Emps.UpdatedBy = globalData.UserID;
        //            Emps.CreatedDate = DateTime.Now;
        //            Emps.UpdatedDate = DateTime.Now;
        //            Repo.Update(Emps);
        //            LoggedUser.CreateActionLog(5070, globalData.UserID, 3, Emps.Id, "Employees/الموظفين");

        //            var q = Session["ID"] = db.SalesINV.Max(x => x.Id);
        //            if (db.SaveChanges() > 0)
        //            {
        //                return new JsonResult { Data = new { status = status, message = "order add successfully" } };
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }

        //        return new JsonResult { Data = new { status = status, message = "order add successfully" } };
        //    }
        //}

        //public JsonResult GetEmpsFilter(int? EmpId = 0,int? EmpName=0, int? DepartmentId = 0 , int? JobTitle= 0, string Active="")
        //{
        //    var _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).ToList().OrderByDescending(a => a.Id);
        //    if (EmpId != 0 )
        //    {
        //         _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).Where(a=>a.Id==EmpId).ToList().OrderByDescending(a => a.Id);


        //    }
        //    else if(EmpName != 0)
        //    {
        //        _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).Where(a => a.Id == EmpName).ToList().OrderByDescending(a => a.Id);
        //    }

        //    else if (DepartmentId != 0 )
        //    {
        //        _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).Where(a => a.DepartmentId == DepartmentId).ToList().OrderByDescending(a => a.Id);
        //    }
        //    else if (Active == "true" )
        //    {
        //        _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).Where(a => a.IsEmpActive == true).ToList().OrderByDescending(a => a.Id);
        //    }

        //    else if (Active == "false" )
        //    {
        //        _Obj = db.Employees.Include(a => a.Country).Include(a => a.Bank).Include(a => a.Qualification).Include(a => a.JobTitles).Include(a => a.Department).Where(a => a.IsDeleted == false).Where(a => a.IsEmpActive == false).ToList().OrderByDescending(a => a.Id);
        //    }
        //    return Json(_Obj, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Delete(int ID)
        //{
        //    LoggedUser.CreateActionLog(5070, globalData.UserID, 5, ID, "Employees/الموظفين");

        //    return Json(Repo.Remove(ID), JsonRequestBehavior.AllowGet);

        //}

    }
}