using DataMapping.Entites;
using DataMapping.ViewModel;
using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWeb.Models;

namespace DiteToDoor.Controllers
{
    public class MenusController : MyController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        MenusRepository Repo = new MenusRepository();
        GlobalData globalData = HelperMethods.globalData;

        // GET: Menus
        public ActionResult Index()
        {
            var mealsDates = db.MenuByDateWebNutrition.Where(a => a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();

            return View(mealsDates);
        }
        // Meal Number 1 
        [HttpGet]
        public ActionResult AddOrEditBreakFast(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program==globalData.CProgramID&& a.ConvertTProgramType == globalData.CProgramType).ToList();
           return PartialView("ModelCreatePopupBreakfastPartialView",Meals);
             
            }
        [HttpPost]
        public ActionResult AddOrEditBreakFast(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;
           
            Repo.InsertBreakFast(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 2

        [HttpGet]
        public ActionResult AddOrEditBreakfastSide(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupBreakfastSidePartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditBreakfastSide(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertBreakfastSide(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 3

        [HttpGet]
        public ActionResult AddOrEditMorningSnack(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupMorningSnackPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditMorningSnack(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertMorningSnack(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 4

        [HttpGet]
        public ActionResult AddOrEditLunchProtien(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupLunchProtienPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditLunchProtien(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertLunchProtien(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 5

        [HttpGet]
        public ActionResult AddOrEditLunchStarchySide(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupLunchStarchySidePartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditLunchStarchySide(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertLunchStarchySide(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 6 

        [HttpGet]
        public ActionResult AddOrEditLunchVeggieSide(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupLunchVeggieSidePartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditLunchVeggieSide(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertLunchVeggieSide(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 7

        [HttpGet]
        public ActionResult AddOrEditLunchSalad(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupLunchSaladPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditLunchSalad(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertLunchSalad(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 8

        [HttpGet]
        public ActionResult AddOrEditAfternoon(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupAfternoonPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditAfternoon(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertAfternoon(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 9 

        [HttpGet]
        public ActionResult AddOrEditDinner(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupDinnerPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditDinner(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertDinner(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        // Meal Number 10

        [HttpGet]
        public ActionResult AddOrEditBedtimeSnack(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date && a.Program == globalData.CProgramID && a.ConvertTProgramType == globalData.CProgramType).ToList();
            return PartialView("ModelCreatePopupBedtimeSnackPartialView", Meals);

        }
        [HttpPost]
        public ActionResult AddOrEditBedtimeSnack(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;

            Repo.InsertBedtimeSnack(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }


    }
    }
