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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace DiteToDoor.Controllers
{
    public class SignUpFormController : MyController
    {
        // GET: SignUpForm
        SignFormRepository rep = new SignFormRepository();
        MyGoalsRepository MyGoalsRepo = new MyGoalsRepository();
        FoodFrequencyRepository FoodRepo = new FoodFrequencyRepository();
      
        GlobalData globalData = HelperMethods.globalData;

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Item/AddOrEdit
        public ActionResult Index()
        {
            ViewBag.CanAdd = false;
            ViewBag.CanEdit = false;
            ViewBag.CanDelete = false;
            bool flagAdd = LoggedUser.InRole("Item", "create");
            bool flagEdit = LoggedUser.InRole("Item", "edit");
            bool flagDelete = LoggedUser.InRole("Item", "delete");
            if (flagAdd)
            {
                ViewBag.CanAdd = true;
            }
            if (flagEdit)
            {
                ViewBag.CanEdit = true;
            }
            if (flagDelete)
            {
                ViewBag.CanDelete = true;
            }
            var result = rep.GetAll();
            //if (globalData.UserID != 0)
            //{
            //    LoggedUser.CreateActionLog(2003, globalData.UserID, 1, 0, "Item / الأصناف");

            //}

            return View(result);
        }

      



       
        //اضفه صنف
        public ActionResult AddOrEdit(int? id = 0)
        {
            List<SelectListItem> Gender = new List<SelectListItem>();
            Gender.Add(new SelectListItem() { Text = "ذكر ", Value = "1" });
            Gender.Add(new SelectListItem() { Text = "أنثى ", Value = "2" });
           

            ViewBag.Type = new SelectList(Gender, "Value", "Text");
            if (id == 0)
            {

              
                return View();
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(SignForm _Item, HttpPostedFileBase file)
        {
            if (_Item.Id == 0)
            {
                rep.Insert(_Item);
                var record = db.SignForm.Max(a => a.Id);
                //if (globalData.UserID != 0)
                //{
                //    LoggedUser.CreateActionLog(2003, globalData.UserID, 2, record, "Item / الأصناف");

                //}
                return Json(true);
            }
            else
            {
                rep.Update(_Item);
                var record = _Item.Id;
                //if (globalData.UserID != 0)
                //{
                //    LoggedUser.CreateActionLog(2003, globalData.UserID, 3, record, "Item / الأصناف");

                //}
                return RedirectToAction(nameof(Index));

            }

        }

        [HttpPost]
        public ActionResult AddFoodFerquencey(FoodFrequency _Item)
        {
            if (_Item.Id == 0)
            {
                var record = db.SignForm.Max(a => a.Id);

                _Item.UserId = record;
                FoodRepo.Insert(_Item);
                //if (globalData.UserID != 0)
                //{
                //    LoggedUser.CreateActionLog(2003, globalData.UserID, 2, record, "Item / الأصناف");

                //}
                return RedirectToAction(nameof(Index));
            }
            else
            {
                FoodRepo.Update(_Item);
                var record = _Item.Id;
                //if (globalData.UserID != 0)
                //{
                //    LoggedUser.CreateActionLog(2003, globalData.UserID, 3, record, "Item / الأصناف");

                //}
                return RedirectToAction(nameof(Index));

            }

        }

        [HttpPost]
        public ActionResult AddMyGoals()
        {
          
            var d = db.TempGoals.ToList();
            MyGoalsRepo.InsertList(d);
            return Json(true);
        }
        public ActionResult AddItem(int? id = 0)
        {
            if (id == 0)
            {

                return View();
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public ActionResult AddItem(SignForm _Item, HttpPostedFileBase file)
        {
            if (_Item.Id == 0)
            {
                rep.Insert(_Item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                rep.Update(_Item);
                return RedirectToAction(nameof(Index));

            }

        }

        public ActionResult Delete(int id)
        {
            var q = rep.Remove(id);
            //if (globalData.UserID != 0)
            //{
            //    LoggedUser.CreateActionLog(2003, globalData.UserID, 5, id, "Item / الأصناف");

            //}

            return RedirectToAction(nameof(Index));
        }

        //ItemSubUint
        public JsonResult ItemSubUintList()
        {
            int? ItemId = db.SignForm.Max(a => (int?)a.Id);
            return Json(db.MyGoals.Where(a => a.IsDeleted == false && a.UserId == ItemId).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ItemSubUintListTemp()
        {
            int? ItemId = db.SignForm.Max(a => (int?)a.Id);
            return Json(db.TempGoals.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SubUintAddOrEdit(int id = 0)
        {


            if (id == 0)
            {
                ViewBag.GoalId = new SelectList(db.Goals.ToList(), "Id", "Name");

                return PartialView("SubUnitModelCreatePopupPartialView");
            }
            else
            {
                var data = db.MyGoals.SingleOrDefault(a => a.Id == id);
                ViewBag.GoalId = new SelectList(db.Goals.ToList(), "Id", "Name",data.GoalId);

                return PartialView("SubUnitModelEditPopupPartialView", data);
            }

        }
        [HttpPost]
        public ActionResult SubUintAddOrEdit(MyGoals _ItemSubUint)
        {


            if (_ItemSubUint.Id == 0)
            {
                TempGoals temp = new TempGoals();
                temp.GoalId = _ItemSubUint.GoalId;

                var succsses = MyGoalsRepo.Insert(_ItemSubUint);
                if (succsses)
                {
                    return Json(Url.Action("Index", "Item"));
                }
                else
                {
                    return PartialView("SubUnitModelCreatePopupPartialView");
                }
            }
            else
            {

                MyGoalsRepo.Update(_ItemSubUint);
                return Json(Url.Action("Index", "Item"));

            }

        }


        [HttpGet]
        public ActionResult SubUintAddOrEditTemp(int id = 0)
        {


            if (id == 0)
            {
                return PartialView("SubUnitModelCreatePopupPartialViewTemp");
            }
            else
            {
                var data = db.TempGoals.SingleOrDefault(a => a.Id == id);
                return PartialView("SubUnitModelEditPopupPartialViewTemp", data);
            }

        }
        [HttpPost]
        public ActionResult SubUintAddOrEditTemp(TempGoals temp)
        {


            if (temp.Id == 0)
            {


                var succsses = MyGoalsRepo.InsertTemp(temp);
                if (succsses)
                {
                    return Json(Url.Action("Index", "Item"));
                }
                else
                {
                    return PartialView("SubUnitModelCreatePopupPartialView");
                }
            }
            else
            {

                MyGoalsRepo.UpdateTemp(temp);
                return Json(Url.Action("Index", "Item"));

            }

        }
        public JsonResult DeleteSubUint(int id)
        {

            return Json(MyGoalsRepo.Remove(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSubUintTemp(int id)
        {

            return Json(MyGoalsRepo.RemoveTemp(id), JsonRequestBehavior.AllowGet);
        }
        //ItemOpeningBalance
        public JsonResult ItemOpeningBalanceList(int id = 0)
        {
            var ItemId = db.SignForm.SingleOrDefault(a => a.Id == id).Id;
            return Json(db.FoodFrequency.Where(a => a.UserId == ItemId).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult OpeningBalanceAddOrEdit(int id = 0)
        {


            if (id == 0)
            {

                return PartialView("OpeningBalanceModelCreatePopupPartialView");
            }
            else
            {
                var data = db.FoodFrequency.SingleOrDefault(a => a.Id == id);
                return PartialView("OpeningBalanceModelEditPopupPartialView", data);
            }

        }
        [HttpPost]
        public ActionResult OpeningBalanceAddOrEdit(FoodFrequency _OpeningBlance)
        {

            if (_OpeningBlance.Id == 0)
            {
                var openingBalance = db.FoodFrequency.Where(a => a.UserId == _OpeningBlance.UserId).FirstOrDefault();
                if (openingBalance == null)
                {

                    FoodRepo.Insert(_OpeningBlance);
                    return Json(Url.Action("Index", "Item"));
                }
                else
                {
                    return PartialView("OpeningBalanceModelCreatePopupPartialView");
                }

            }
            else
            {

                FoodRepo.Update(_OpeningBlance);
                return Json(Url.Action("Index", "Item"));

            }

        }

        public JsonResult DeleteOpenBalance(int id)
        {
            return Json(FoodRepo.Remove(id), JsonRequestBehavior.AllowGet);
        }

        

        //تعديل صنف
        public ActionResult EditItem(int id = 0)
        {
            Session["MainItemId"] = id;
            TempData["MainItemId"] = id;
            var Data = db.SignForm.SingleOrDefault(a => a.Id == id);
            return View(Data);

        }
        //ItemSubUint
        //تعديل وحدات الاصناف
        public JsonResult EditItemSubUintList()
        {
            int MainItemId = Convert.ToInt32(Session["MainItemId"]);
            return Json(db.MyGoals.Where(a =>  a.UserId == MainItemId).ToList(), JsonRequestBehavior.AllowGet);
        }
        //تعديل الارصده الافتتاحية للصنف
        public JsonResult EditItemOpeningBalanceList()
        {
            int MainItemId = Convert.ToInt32(Session["MainItemId"]);
            var OpeningBalanceList = db.FoodFrequency.Where(a =>  a.UserId == MainItemId).ToList();
            return Json(OpeningBalanceList, JsonRequestBehavior.AllowGet);
        }





        public ActionResult GenerateBarCode(string text)
        {

            using (MemoryStream ms = new MemoryStream())
            {

                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(text.Length * 20, 40))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black); ;
                        graphics.DrawString(text, oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.

                    bitMap.Save(ms, ImageFormat.Jpeg);

                    //The Image is finally converted to Base64 string.
                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    return Json("data:image/png;base64," + Convert.ToBase64String(ms.ToArray()), JsonRequestBehavior.AllowGet);
                }
            }
        }



    }
}