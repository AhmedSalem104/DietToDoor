using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using ERPWeb.Models.SecurityRoles;
using ERPWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWEB.Controllers
{
    public class SystemSettingsController :MyController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        CompanyInfoRepository repCompanyInfo = new CompanyInfoRepository();
        InvoicesSettingsRepository repInvoicesSettings = new InvoicesSettingsRepository();

        GlobalData globalData = HelperMethods.globalData;
        SystemSettingsModel systemSettings = new SystemSettingsModel();

        // GET: SystemSetings
        public ActionResult Index()
        {
           
            if (globalData.UserID != 0) {
                LoggedUser.CreateActionLog(2, globalData.UserID, 1, 0, "System Setting / إعدادات النظام");

            }

            //dynamic myDynamicmodel = new System.Dynamic.ExpandoObject();
            //myDynamicmodel.CompanyInfo = db.CompanyInfo.FirstOrDefault();
            var comInfos = db.CompanyInfo.FirstOrDefault();
            var SalesInvoiceSettings = db.InvoicesSettings.FirstOrDefault();
            //var Qutations = db.InvoicesSettings.FirstOrDefault(a => a.FormName == "Qutations");
            //var PurchaseOrder = db.InvoicesSettings.FirstOrDefault(a => a.FormName == "PurchaseOrders");
            //var Purchase = db.InvoicesSettings.FirstOrDefault(a => a.FormName == "Purchases");
            //var Docs = db.InvoicesSettings.FirstOrDefault(a => a.FormName == "Docs");

            if (comInfos != null)
            {
                systemSettings.CompanyInfo = comInfos;

                //ViewBag.CountryId = new SelectList(db.Country.ToList(), "Id", "CountryName", comInfos.CountryId);
                //ViewBag.GovernatesId = new SelectList(db.Governates.ToList(), "Id", "GovernateName", comInfos.GovernatesId);
                //ViewBag.CityId = new SelectList(db.City.ToList(), "Id", "CityName", comInfos.CityId);
                //ViewBag.CurrenciesId = new SelectList(db.Currencies.ToList(), "Id", "CurrenciesName", comInfos.CurrenciesId);
            }
            else
            {
                //ViewBag.CountryId = new SelectList(db.Country.ToList(), "Id", "CountryName");
                //ViewBag.GovernatesId = new SelectList(db.Governates.ToList(), "Id", "GovernateName");
                //ViewBag.CityId = new SelectList(db.City.ToList(), "Id", "CityName");
                //ViewBag.CurrenciesId = new SelectList(db.Currencies.ToList(), "Id", "CurrenciesName");
                systemSettings.CompanyInfo = new CompanyInfo();
                //var companyInfo = db.CompanyInfo.FirstOrDefault();
                //if (companyInfo != null) {
                //    return View(companyInfo);
                //}
                //else 
                //{
                //    return View();
                //}
            }
            if (SalesInvoiceSettings != null)
            {
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearName",SalesInvoiceSettings.YearId).ToList();
                systemSettings.InvoicesSettings = SalesInvoiceSettings;
            }
            else
            {
                ViewBag.YearId = new SelectList(db.Years, "YearId", "YearName").ToList();
                systemSettings.InvoicesSettings = new InvoicesSettings();
            }


            //if (Qutations != null)
            //{
            //    systemSettings.Qutations = Qutations;
            //}
            //else {
            //    systemSettings.Qutations = new InvoicesSettings();
            //}
            //if (PurchaseOrder != null)
            //{
            //    systemSettings.PurchaseOrders = PurchaseOrder;
            //}
            //else {
            //    systemSettings.PurchaseOrders = new InvoicesSettings();
            //}
            //if (Purchase != null)
            //{
            //    systemSettings.Purchases = Purchase;
            //}
            //else {
            //    systemSettings.Purchases = new InvoicesSettings();

            //}
            //if (Docs != null)
            //{
            //    systemSettings.Docs = Docs;
            //}
            //else {
            //    systemSettings.Purchases = new InvoicesSettings();

            //}
            return View(systemSettings);

        }

        //public ActionResult AddOrEditCompanyInfo(int id = 0)
        //{
        //    //ViewBag.DateNow = DateTime.Now.ToString("dd/MM/yyyy");
        //    //if (id == 0)
        //    //{
        //        ViewBag.EmployeeId = new SelectList(db.Employee.ToList(), "Id", "EmployeeNameAr");
        //        return View();
        //    //}
        //    //else
        //    //{
        //    //    var data = db.User.SingleOrDefault(a => a.Id == id);
        //    //    ViewBag.EmployeeId = new SelectList(db.Employee.ToList(), "Id", "EmployeeNameAr", data.EmployeeId);

        //    //    return View(rep.GetById(id));
        //    //}
        //}
        [HttpPost]
        public ActionResult AddOrEditCompanyInfo(SystemSettingsModel _CompanyInfo, HttpPostedFileBase file)
        {
            CompanyInfo companyInfo = new CompanyInfo();

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
                    companyInfo.Image = "~/UploadImages/" + file.FileName;
                }
            }
            else
            {
                companyInfo.Image = "~/ImgNotFound/images.jpg";
            }
            if (_CompanyInfo.CompanyInfo.Id == 0)
            {
           
                companyInfo.CompanyName = _CompanyInfo.CompanyInfo.CompanyName;
                companyInfo.CompanyAddress = _CompanyInfo.CompanyInfo.CompanyAddress;
                companyInfo.Mobile = _CompanyInfo.CompanyInfo.Mobile;
                companyInfo.Phone = _CompanyInfo.CompanyInfo.Phone;
                companyInfo.MaintananceManager = _CompanyInfo.CompanyInfo.MaintananceManager;
                companyInfo.CompanyManager = _CompanyInfo.CompanyInfo.CompanyManager;
                companyInfo.MovementManager = _CompanyInfo.CompanyInfo.MovementManager;
                companyInfo.Employee1 = _CompanyInfo.CompanyInfo.Employee1;
                companyInfo.Employee2 = _CompanyInfo.CompanyInfo.Employee2;
                companyInfo.Email = _CompanyInfo.CompanyInfo.Email;
                companyInfo.PostalCode = _CompanyInfo.CompanyInfo.PostalCode;
                companyInfo.TaxNumber = _CompanyInfo.CompanyInfo.TaxNumber;
                companyInfo.Image = _CompanyInfo.CompanyInfo.Image;
                companyInfo.FiscalYearStartDate = _CompanyInfo.CompanyInfo.FiscalYearStartDate;
                companyInfo.FiscalYearEndDate = _CompanyInfo.CompanyInfo.FiscalYearEndDate;
                companyInfo.CountryId =  _CompanyInfo.CompanyInfo.CountryId;           
                companyInfo.GovernatesId = _CompanyInfo.CompanyInfo.GovernatesId;
                companyInfo.CityId = _CompanyInfo.CompanyInfo.CityId;
                companyInfo.CurrenciesId = _CompanyInfo.CompanyInfo.CurrenciesId;
              

                repCompanyInfo.Insert(companyInfo);
                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(2, globalData.UserID, 2, db.Users.Max(a => a.Id), "System Setting / إعدادات النظام");

                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                companyInfo.Id = _CompanyInfo.CompanyInfo.Id;
                companyInfo.CompanyName = _CompanyInfo.CompanyInfo.CompanyName;
                companyInfo.CompanyAddress = _CompanyInfo.CompanyInfo.CompanyAddress;
                companyInfo.Mobile = _CompanyInfo.CompanyInfo.Mobile;
                companyInfo.Phone = _CompanyInfo.CompanyInfo.Phone;
                companyInfo.MaintananceManager = _CompanyInfo.CompanyInfo.MaintananceManager;
                companyInfo.CompanyManager = _CompanyInfo.CompanyInfo.CompanyManager;
                companyInfo.MovementManager = _CompanyInfo.CompanyInfo.MovementManager;
                companyInfo.Employee1 = _CompanyInfo.CompanyInfo.Employee1;
                companyInfo.Employee2 = _CompanyInfo.CompanyInfo.Employee2;
                companyInfo.Email = _CompanyInfo.CompanyInfo.Email;
                companyInfo.PostalCode = _CompanyInfo.CompanyInfo.PostalCode;
                companyInfo.TaxNumber = _CompanyInfo.CompanyInfo.TaxNumber;
                companyInfo.Image = _CompanyInfo.CompanyInfo.Image;
                companyInfo.FiscalYearStartDate = _CompanyInfo.CompanyInfo.FiscalYearStartDate;
                companyInfo.FiscalYearEndDate = _CompanyInfo.CompanyInfo.FiscalYearEndDate;
                companyInfo.CountryId = _CompanyInfo.CompanyInfo.CountryId;
                companyInfo.GovernatesId = _CompanyInfo.CompanyInfo.GovernatesId;
                companyInfo.CityId = _CompanyInfo.CompanyInfo.CityId;
                companyInfo.CurrenciesId = _CompanyInfo.CompanyInfo.CurrenciesId;
                repCompanyInfo.Update(companyInfo);

                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(2, globalData.UserID, 3, _CompanyInfo.CompanyInfo.Id, "System Setting / إعدادات النظام");

                }

                return RedirectToAction(nameof(Index));

            }

        }

        [HttpPost]
        public ActionResult AddOrEditSalesInoicesSettings(SystemSettingsModel _InvoicesSettings)
        {
            InvoicesSettings invoicesSettings = new InvoicesSettings();

            string path = "";

            if (_InvoicesSettings.InvoicesSettings.InvoicesSettingId == 0)
            {

                //invoicesSettings.FormName = "General";
                //invoicesSettings.InvoicesSettingId = _InvoicesSettings.InvoicesSettings.InvoicesSettingId;
                invoicesSettings.YearId = _InvoicesSettings.InvoicesSettings.YearId;
                invoicesSettings.Conditions = _InvoicesSettings.InvoicesSettings.Conditions;
                invoicesSettings.Notes = _InvoicesSettings.InvoicesSettings.Notes;
                //invoicesSettings.Conditions = _InvoicesSettings.InvoicesSettings.Conditions;
                //invoicesSettings.RemindPeriod = _InvoicesSettings.InvoicesSettings.RemindPeriod;
                //invoicesSettings.SendEmail = _InvoicesSettings.InvoicesSettings.SendEmail;
                //invoicesSettings.Notes = _InvoicesSettings.InvoicesSettings.Notes;
                //invoicesSettings.Editable = _InvoicesSettings.InvoicesSettings.Editable;
                //invoicesSettings.Tax = _InvoicesSettings.InvoicesSettings.Tax;


                repInvoicesSettings.Insert(invoicesSettings);
                int? year = Convert.ToInt32(db.Years.FirstOrDefault(a => a.YearId == invoicesSettings.YearId).YearName);
                globalData.Year = year;

                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(2, globalData.UserID, 2, db.Users.Max(a => a.Id), "System Setting / إعدادات النظام");

                }

                return RedirectToAction(nameof(Index));
            }
            else 
            {
                //invoicesSettings.Id = _InvoicesSettings.InvoicesSettings.Id;
                //invoicesSettings.FormName = "General";
                invoicesSettings.InvoicesSettingId = _InvoicesSettings.InvoicesSettings.InvoicesSettingId;
                invoicesSettings.YearId = _InvoicesSettings.InvoicesSettings.YearId;
                invoicesSettings.Conditions = _InvoicesSettings.InvoicesSettings.Conditions;
                invoicesSettings.Notes = _InvoicesSettings.InvoicesSettings.Notes;

              
                //invoicesSettings.Conditions = _InvoicesSettings.InvoicesSettings.Conditions;
                //invoicesSettings.RemindPeriod = _InvoicesSettings.InvoicesSettings.RemindPeriod;
                //invoicesSettings.SendEmail = _InvoicesSettings.InvoicesSettings.SendEmail;
                //invoicesSettings.Notes = _InvoicesSettings.InvoicesSettings.Notes;
                //invoicesSettings.Editable = _InvoicesSettings.InvoicesSettings.Editable;
                //invoicesSettings.Tax = _InvoicesSettings.InvoicesSettings.Tax;

                repInvoicesSettings.Update(invoicesSettings);
                int? year = Convert.ToInt32(db.Years.FirstOrDefault(a => a.YearId == invoicesSettings.YearId).YearName);
                globalData.Year = year;
                if (globalData.UserID != 0)
                {
                    LoggedUser.CreateActionLog(2, globalData.UserID, 3, invoicesSettings.InvoicesSettingId, "System Setting / إعدادات النظام");

                }

                return RedirectToAction(nameof(Index));

            }
            //else
            //{
            //    return RedirectToAction(nameof(Index));

            //}
        }

        //[HttpPost]
        //public ActionResult AddOrEditQutationsSettings(SystemSettingsModel _InvoicesSettings)
        //{
        //    InvoicesSettings invoicesSettings = new InvoicesSettings();


        //    if (_InvoicesSettings.Qutations.Id == 0)
        //    {

        //        invoicesSettings.FormName = "Qutations";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Qutations.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Qutations.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Qutations.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Qutations.RemindPeriod;
        //        invoicesSettings.SendEmail = _InvoicesSettings.Qutations.SendEmail;
        //        invoicesSettings.Notes = _InvoicesSettings.Qutations.Notes;
        //        invoicesSettings.Editable = _InvoicesSettings.Qutations.Editable;



        //        repInvoicesSettings.Insert(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 2, db.User.Max(a => a.Id), "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else if (_InvoicesSettings.Qutations.Id != 0)
        //    {
        //        invoicesSettings.Id = _InvoicesSettings.Qutations.Id;
        //        invoicesSettings.FormName = "Qutations";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Qutations.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Qutations.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Qutations.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Qutations.RemindPeriod;
        //        invoicesSettings.SendEmail = _InvoicesSettings.Qutations.SendEmail;
        //        invoicesSettings.Notes = _InvoicesSettings.Qutations.Notes;
        //        invoicesSettings.Editable = _InvoicesSettings.Qutations.Editable;

        //        repInvoicesSettings.Update(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 3, invoicesSettings.Id, "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));

        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));

        //    }
        //}

        //[HttpPost]
        //public ActionResult AddOrEditPurchaseOrderSettings(SystemSettingsModel _InvoicesSettings)
        //{
        //    InvoicesSettings invoicesSettings = new InvoicesSettings();


        //    if (_InvoicesSettings.PurchaseOrders.Id == 0)
        //    {

        //        invoicesSettings.FormName = "PurchaseOrders";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.PurchaseOrders.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.PurchaseOrders.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.PurchaseOrders.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.PurchaseOrders.RemindPeriod;
        //        invoicesSettings.SendEmail = _InvoicesSettings.PurchaseOrders.SendEmail;
        //        invoicesSettings.Notes = _InvoicesSettings.PurchaseOrders.Notes;

        //        invoicesSettings.Editable = _InvoicesSettings.PurchaseOrders.Editable;


        //        repInvoicesSettings.Insert(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 2, db.User.Max(a => a.Id), "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else if (_InvoicesSettings.PurchaseOrders.Id != 0)
        //    {
        //        invoicesSettings.Id = _InvoicesSettings.PurchaseOrders.Id;
        //        invoicesSettings.FormName = "PurchaseOrders";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.PurchaseOrders.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.PurchaseOrders.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.PurchaseOrders.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.PurchaseOrders.RemindPeriod;
        //        invoicesSettings.SendEmail = _InvoicesSettings.PurchaseOrders.SendEmail;
        //        invoicesSettings.Notes = _InvoicesSettings.PurchaseOrders.Notes;
        //        invoicesSettings.Editable = _InvoicesSettings.PurchaseOrders.Editable;

        //        repInvoicesSettings.Update(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 3, invoicesSettings.Id, "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));

        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));

        //    }
        //}
        //[HttpPost]
        //public ActionResult AddOrEditPurchasesSettings(SystemSettingsModel _InvoicesSettings)
        //{
        //    InvoicesSettings invoicesSettings = new InvoicesSettings();


        //    if (_InvoicesSettings.Purchases.Id == 0)
        //    {

        //        invoicesSettings.FormName = "Purchases";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Purchases.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Purchases.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Purchases.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Purchases.RemindPeriod;
        //        invoicesSettings.Editable = _InvoicesSettings.Purchases.Editable;
        //        invoicesSettings.Notes = _InvoicesSettings.Purchases.Notes;



        //        repInvoicesSettings.Insert(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 2, db.User.Max(a => a.Id), "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else if (_InvoicesSettings.Purchases.Id != 0)
        //    {
        //        invoicesSettings.Id = _InvoicesSettings.Purchases.Id;
        //        invoicesSettings.FormName = "Purchases";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Purchases.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Purchases.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Purchases.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Purchases.RemindPeriod;
        //        invoicesSettings.Editable = _InvoicesSettings.Purchases.Editable;
        //        invoicesSettings.Notes = _InvoicesSettings.Purchases.Notes;

        //        repInvoicesSettings.Update(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 3, invoicesSettings.Id, "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));

        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));

        //    }
        //}

        //[HttpPost]
        //public ActionResult AddOrEditDocsSettings(SystemSettingsModel _InvoicesSettings)
        //{
        //    InvoicesSettings invoicesSettings = new InvoicesSettings();


        //    if (_InvoicesSettings.Docs.Id == 0)
        //    {

        //        invoicesSettings.FormName = "Docs";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Docs.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Docs.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Docs.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Docs.RemindPeriod;
        //        invoicesSettings.Editable = _InvoicesSettings.Docs.Editable;
        //        invoicesSettings.Notes = _InvoicesSettings.Docs.Notes;



        //        repInvoicesSettings.Insert(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 2, db.User.Max(a => a.Id), "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));
        //    }
        //    else if (_InvoicesSettings.Docs.Id != 0)
        //    {
        //        invoicesSettings.Id = _InvoicesSettings.Docs.Id;
        //        invoicesSettings.FormName = "Docs";
        //        invoicesSettings.IDPrefix = _InvoicesSettings.Docs.IDPrefix;
        //        invoicesSettings.IDStart = _InvoicesSettings.Docs.IDStart;
        //        invoicesSettings.Conditions = _InvoicesSettings.Docs.Conditions;
        //        invoicesSettings.RemindPeriod = _InvoicesSettings.Docs.RemindPeriod;
        //        invoicesSettings.Editable = _InvoicesSettings.Docs.Editable;
        //        invoicesSettings.Notes = _InvoicesSettings.Docs.Notes;

        //        repInvoicesSettings.Update(invoicesSettings);
        //        LoggedUser.CreateActionLog(3, globalData.UserID, 3, invoicesSettings.Id, "Users / المستخدمين");

        //        return RedirectToAction(nameof(Index));

        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(Index));

        //    }
        //}
        //public JsonResult GetCitiesList(int? ID)
        //{
        //    if (ID is null)
        //    {
        //        throw new ArgumentNullException(nameof(ID));
        //    }
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {

        //        db.Configuration.ProxyCreationEnabled = false;
        //        var city = db.City.Where(a => a.IsDeleted == false && a.GovernatesId == ID).ToList();

        //        return Json(city, JsonRequestBehavior.AllowGet);




        //    }
        //}
    }
}