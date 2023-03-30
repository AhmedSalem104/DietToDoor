using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWeb.Models.SecurityRoles;
using System.Net.Mail;
using DataMapping.Entites;

namespace Maintanence.Controllers
{
    public class HomeController : MyController
    {
        GlobalData globalData = HelperMethods.globalData;

        public ActionResult Index()
        {
            
            return View();
        }


        [HttpGet]
        public ActionResult SendMessage()
        {
            return PartialView("ModelCreatePopupPartialView");
        }
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {



            if (ModelState.IsValid)
            {

                var mail = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("ahmedalgazar065@gmail.com", "zqwmdjijheatpwnn");
                //var loginInfo = new NetworkCredential("ahmedalgazar065@gmail.com", "ahmed1041998###");
                mail.From = new MailAddress("ahmed.java97@gmail.com");
                mail.To.Add(new MailAddress(contact.Email));
                mail.Subject = contact.Subject;
                mail.IsBodyHtml = true;
                string body = "اسم المرسل:" + contact.Name + "<br>" +
                              "بريد المرسل:" + contact.Email + "<br>" +
                              "عنوان الرسالة:" + contact.Subject + "<br>" +
                              "محتوى الرسالة: <b>" + contact.Message + "<b>";
                mail.Body = body;

                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                Session["session"] = " تم ارسال رسالتك ";

                return RedirectToAction("Index");

            }
            else
            {
                Session["session"] = "نعتذر حد خطا يرجى ملى البيانات";

            }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}