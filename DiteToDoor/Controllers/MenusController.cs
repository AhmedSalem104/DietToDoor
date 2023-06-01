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
    public class MenusController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        MenusRepository Repo = new MenusRepository();
        GlobalData globalData = HelperMethods.globalData;

        // GET: Menus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEdit(string DateDay)
        {
            var date = DateTime.Parse(DateDay);
            var Meals = db.MenuByDateWebNutrition.Where(a => a.DateDay == date).ToList();
           return PartialView("ModelCreatePopupBreakfastPartialView",Meals);
             
            }


        [HttpPost]
        public ActionResult AddOrEdit(WeeklyMealsViewModel item)
        {
            bool status = true;
            item.ClientId = globalData.ClientId;
            item.CreateDate = DateTime.Now;
           
            Repo.InsertBreakFast(item);
            return new JsonResult { Data = new { status = status, message = "order add successfully" } };

        }

        
    }
    }
