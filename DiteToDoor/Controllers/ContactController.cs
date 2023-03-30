using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DiteToDoor.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage(int id = 0)
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
                mail.From = new MailAddress(contact.Email);
                mail.To.Add(new MailAddress("Ibrahim.moftah@gmail.com"));
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

                return RedirectToAction("Contact");

            }
            else
            {
                Session["session"] = "نعتذر حد خطا يرجى ملى البيانات";

            }
            return View("Index");
        }
    }
}