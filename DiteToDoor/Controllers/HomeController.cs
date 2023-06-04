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
//using MimeKit;

namespace Maintanence.Controllers
{
    public class HomeController : MyController
    {
        GlobalData globalData = HelperMethods.globalData;
        private ApplicationDbContext db = new ApplicationDbContext();
        FollowUpRepository FollowUprep = new FollowUpRepository();
        ContactUsRepository ContactUsrep = new ContactUsRepository();


        public ActionResult Index()
        {
            Session["ClientName"] = globalData.CName;
            Session["ClientAddres"] = globalData.CAddres;
            Session["ClientTel2"] = globalData.CTel2;
    
            return View();
        }



        [HttpPost]
        public ActionResult SendGmailMessageFollowUp(FollowUp followUp)
        {



            //sending the Message of passwordResetLink
            //using (var client = new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587);
            //    client.Authenticate("ahmedalgazar065@gmail.com", "zqwmdjijheatpwnn");
            //    var bodybuilder = new BodyBuilder
            //    {
            //        HtmlBody = $"to Reset Your Password Please Click This link ",
            //        TextBody = "wellcome",
            //    };
            //    var message = new MimeMessage
            //    {
            //        Body = bodybuilder.ToMessageBody()
            //    };
            //    message.From.Add(new MailboxAddress("Future Team", "mofouad820@gmail.com"));
            //    message.To.Add(new MailboxAddress("testing", email));
            //    message.Subject = "new Contact Submitted Data";
            //    await client.SendAsync(message);
            //    client.Disconnect(true);
            //}
            //end of sending email


            if (ModelState.IsValid)
            {

                var mail = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //smtpClient.Credentials = new System.Net.NetworkCredential("ahmedalgazar065@gmail.com", "zqwmdjijheatpwnn");
                smtpClient.Credentials = new System.Net.NetworkCredential("diettodoor@gmail.com", "ssjihwgqkyowojwz");
                mail.From = new MailAddress("diettodoor@gmail.com");
                mail.To.Add(new MailAddress("diettodoor@gmail.com"));
                mail.Subject = "متابعة من العميل" + globalData.CName ; 
                mail.IsBodyHtml = true;
                string body = "اسم العميل:" + globalData.CName + "<br>" +
                              "وزن العميل :" + followUp.CurrentWeight + "<br>" +
                              "محيط الوسط :" + followUp.CurrentCenterOfCircumference + "<br>" +
                               //" ملاحظات : <b>" + followUp.Notes + "<br>" +
                              "عنوان العميل : <b>" + globalData.CAddres + "<br>"+
                              "رقم العميل : <b>" + globalData.CTel2 + "<br>";
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
                smtpClient.Credentials = new System.Net.NetworkCredential("diettodoor@gmail.com", "ssjihwgqkyowojwz");
                mail.From = new MailAddress("diettodoor@gmail.com");
                mail.To.Add(new MailAddress("diettodoor@gmail.com"));
                mail.Subject = " تواصل من العميل " + globalData.CName;
                mail.IsBodyHtml = true;
                string body = "اسم العميل:<b style:color:red;>" + globalData.CName + "<br>" +
                              "حالة العميل :<b>" + ServiceOpinionName + "<br>" +
                              "الغرض من التواصل :<b>" + SubjectName + "<br>" +
                               //"ملاحظات :<b>" + contactUs.NotSatissfied + "<br>" +
                               "عنوان العميل : <b>" + globalData.CAddres + "<br>" +
                              "رقم العميل : <b>" + globalData.CTel2 + "<b>";
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
                ClientId = globalData.ClientId,
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
                ClientId = globalData.ClientId,

                ServiceOpinionId = serviceOpinionId,
                 SubjectId = subjectId,
                Comment = comments,
                Attachment = upload
            };
            ContactUsrep.Insert(_Item);
            SendGmailMessageContactUs(_Item);
            return RedirectToAction(nameof(Index));



        }

    }
}