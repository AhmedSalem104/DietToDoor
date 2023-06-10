using ERPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPWeb.Models.SecurityRoles;
using System.Net.Mail;
using DataMapping.Entites;
using DataAccess.Repositories;

namespace Maintanence.Controllers
{
    public class HomeController : MyController
    {
        GlobalData globalData = HelperMethods.globalData;
        private ApplicationDbContext db = new ApplicationDbContext();
        FollowUpRepository FollowUprep = new FollowUpRepository();
        //ContactUsRepository ContactUsrep = new ContactUsRepository();


        public ActionResult Index()
        {
            
            return View();
        }


        //[HttpGet]
        //public ActionResult SendMessage()
        //{
        //    return PartialView("ModelCreatePopupPartialView");
        //}
        [HttpPost]
        public ActionResult SendGmailMessageFollowUp(FollowUp followUp)
        {


            if (ModelState.IsValid)
            {

                var mail = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("ahmedalgazar065@gmail.com", "zqwmdjijheatpwnn");
                //var loginInfo = new NetworkCredential("ahmedalgazar065@gmail.com", "ahmed1041998###");
                mail.From = new MailAddress("ahmedsalem1041998@gmail.com");
                mail.To.Add(new MailAddress("ahmedsalem1041998@gmail.com"));
                mail.Subject = followUp.Attachment;
                mail.IsBodyHtml = true;
                string body = "اسم العميل:" + globalData.LoginName + "<br>" +
                              "وزن العميل :" + followUp.CurrentWeight  + "<br>" +
                              "محيط الوسط :" + followUp.CurrentCenterOfCircumference + "<br>" +
                              "المرفقات : <b>" + followUp.Attachment + "<b>";
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

        [HttpPost]
        public ActionResult SendGmailMessageContactUs(ContactUs contactUs)
        {
            var SubjectName = db.Subject.FirstOrDefault(a => a.SubjectId == contactUs.SubjectId).SubjectName;
            var ServiceOpinionName = db.ServiceOpinion.FirstOrDefault(a => a.ServiceOpinionId == contactUs.ServiceOpinionId).ServiceOpinionName;


            if (ModelState.IsValid)
            {

                var mail = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("ahmedalgazar065@gmail.com", "zqwmdjijheatpwnn");
                //var loginInfo = new NetworkCredential("ahmedalgazar065@gmail.com", "ahmed1041998###");
                mail.From = new MailAddress("ahmedsalem1041998@gmail.com");
                mail.To.Add(new MailAddress("ahmedsalem1041998@gmail.com"));
                mail.Subject = contactUs.Attachment;
                mail.IsBodyHtml = true;
                string body = "اسم العميل:<b style:color:red;>" + globalData.LoginName + "<br>" +
                              "حالة العميل :<b>" + ServiceOpinionName + "<br>" +
                              "الغرض من التواصل :<b>" + SubjectName + "<br>" +
                              "المرفقات : <b>" + contactUs.Attachment + "<b>";
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

        [HttpPost]
        public ActionResult AddFollowUp(decimal? weight ,decimal? circumference,string comments,string upload)
        {
            FollowUp _Item = new FollowUp()
            {
                CurrentWeight = weight,
                CurrentCenterOfCircumference = circumference,
                Notes = comments,
                Attachment = upload
            };
            FollowUprep.Insert(_Item);
            SendGmailMessageFollowUp(_Item);



                return RedirectToAction(nameof(Index));
            
          

        }

        [HttpPost]
        public ActionResult AddContactUs(int? serviceOpinionId, int? subjectId, string comments, string upload)
        {
            ContactUs _Item = new ContactUs()
            {
                ServiceOpinionId = serviceOpinionId,
                 SubjectId = subjectId,
                Comment = comments,
                Attachment = upload
            };
            //ContactUsrep.Insert(_Item);
            SendGmailMessageContactUs(_Item);
            return RedirectToAction(nameof(Index));



        }

    }
}