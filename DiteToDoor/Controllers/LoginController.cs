using DataAccess.Repositories;
using DataMapping.Entites;
using ERPWeb.Models;
using ERPWeb.Models.SecurityRoles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace StoreSystem.Controllers
{
    public class LoginController : MyController
    {
        public string SplitMacAddress(string macadress)
        {
            for (int Idx = 4; Idx < macadress.Length; Idx += 5)
            {
                macadress = macadress.Insert(Idx, "-");
            }
            return macadress;
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            String tempaddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                    tempaddress = SplitMacAddress(sMacAddress);
                }
            }
            return tempaddress;
        }
        public string SplitMacAddressAfterEnc(string macadress)
        {
            for (int Idx = 5; Idx < macadress.Length; Idx += 6)
            {
                macadress = macadress.Insert(Idx, "-");
            }
            return macadress;
        }
        public string CmpositeMacAddress(string macadress)
        {
            char[] delims = new[] { ':' };
            var CompositMac = macadress.Split(delims);
            string finalMac = String.Empty;

            foreach (var item in CompositMac)
            {
                string inputData = item;
                var data = Regex.Match(inputData, @"\d+").Value;

                int i = Convert.ToInt32(data) * 19;
                finalMac += "-" + item + i;
            }
            return finalMac;
        }
        public string CmpositeMacAddressss(string macadress)
        {
            char[] delims = new[] { '-' };
            var CompositMac = macadress.Split(delims);
            string finalMac = String.Empty;
            string finalresult = "";
            string Supfinalresult = "";
            int ii = 0;
            foreach (var item in CompositMac)
            {

                foreach (var i in item)
                {
                    int x1 = item.IndexOf(i);
                    int m = ASCIIEncoding.ASCII.GetByteCount("MAINTANENCE"); // DiteToDoor
                    if (x1 < 4)
                    {
                        if (x1 == 3)
                        {
                            int result = (x1 * i) + item[x1];
                            string re = result.ToString();
                            finalresult += re;
                        }
                        else
                        {
                            int result = (x1 * i) + item[x1 + 1];
                            string re = result.ToString();

                            finalresult +=m+ re;

                        }
                    }
                }
                ii++;
                if (ii <= 2)
                {

                    finalresult += "-";
                }
                //else {
                //    finalresult.Substring(0, 3);
                //}
            }
            finalMac = finalresult;
            return finalMac;
        }

        public string SubStringMacAddress(string macadress)
        {
            char[] delims = new[] { '-' };
            var CompositMac = macadress.Split(delims);
            string finalMac = String.Empty;
            int x = 0;
            foreach (var item in CompositMac)
            {
                string i = item.Substring(0, 4);
                x++;
                if (x <= 2)
                {
                    finalMac += i + "-";
                }
                else
                {
                    finalMac += i;
                }
            }
            return finalMac;
        }
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            var arr = Convert.ToBase64String(array);
            return Convert.ToBase64String(array);
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        // GET: Login

        ApplicationDbContext db = new ApplicationDbContext();
        GlobalData globalData = HelperMethods.globalData;
        ActivationRepository rep = new ActivationRepository();
        [AllowAnonymous]
        public ActionResult Index(string returnUrl, int? BrancheId)
        {

            Session["IsTrial"] = "";

            var MAC = GetMACAddress();
            var ee = CmpositeMacAddressss(MAC);
            var sup = SubStringMacAddress(ee);

            var IsActive = db.ActivationTbl.SingleOrDefault(a => a.productMac == sup);


            if (IsActive == null)
            {
                Session["Mac"] = sup;
                return RedirectToAction("Activation");
                //return View();
            }
            else
            {

                var encMac = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", sup);
                string finaleEnc = "";
                string supFinalEnc = "";
                string divideSupFinalEnc = "";
                foreach (var c in encMac)
                {
                    int p = (int)c;
                    finaleEnc += p.ToString();
                }
                supFinalEnc = finaleEnc.Substring(0, 15);
                divideSupFinalEnc = SplitMacAddressAfterEnc(supFinalEnc);
                if (IsActive.licenceType == 1 && IsActive.serialKey != divideSupFinalEnc)
                {
                    Session["Mac"] = sup;
                    return RedirectToAction("Activation");

                }
                Session["Mac"] = sup;

                if (IsActive.LoginCount != null)
                {
                    var logCount = Convert.ToInt32(DecryptString("b14ca5898a4e4133bbce2ea2315a1916", IsActive.LoginCount));
                    if (logCount <= 10 && logCount > 0)
                    {
                        Session["IsTrial"] = "لديك  " + logCount + "لعدد مرات تسجيل الدخول ";
                    }
                    else if (logCount > 10 || logCount <= 0)
                    {
                        Session["IsTrial"] = "تم استهلاك الحد الأقصى لعدد مرات تسجيل الدخول";
                    }
                }


                if (globalData.RememberMe == true)
                {
                    var x = db.ActivationTbl.SingleOrDefault(a => a.licenceType == 1).licenceType;
                    if (x == 1)
                    {
                        ViewBag.TestlicenceType = true;

                    }
                    else
                    {
                        ViewBag.TestlicenceType = false;

                    }
                    ViewBag.code = globalData.UserCode;
                    //ViewBag.BrancheId = /*new SelectList(db.Branches.Where(a => a.IsDeleted == false ).ToList(), "Id", "BranchesName")*/null;
                    ViewBag.Password = globalData.Password;
                    //ViewBag.Message = "";
                    return View();
                }
                else
                {
                    var x = db.ActivationTbl.SingleOrDefault(a => a.licenceType == 1);
                    if (x == null)
                    {
                        ViewBag.TestlicenceType = false;
                    }
                    else
                    {
                        ViewBag.TestlicenceType = true;

                    }
                    ViewBag.ReturnUrl = returnUrl;
                    HelperMethods.globalData.UserCode = null;
                    //ViewBag.Message = "";
                    return View();
                }
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Users user, int Lang, string returnUrl, int? BrancheId = 0)
        {
            Authentication authen = new Authentication();
            string Message = default(string);
            var Encryptedpassword = Cryptography.EncryptPassword(user.Password, null);
            var userIformationWithDate = db.Users.Where(u => u.Code == user.Code && u.Password == user.Password && u.ToDate >= DateTime.Now).FirstOrDefault();
            var userIformation = db.Users.Where(u => u.Code == user.Code && u.Password == user.Password).FirstOrDefault();
            var MAC = GetMACAddress();
            var ee = CmpositeMacAddressss(MAC);
            var sup = SubStringMacAddress(ee);
            var IsActive = db.ActivationTbl.SingleOrDefault(a => a.productMac == sup);
            if (userIformation != null && userIformationWithDate != null)
            {
                if (IsActive.LoginCount != null)
                {
                    var logCount = Convert.ToInt32(DecryptString("b14ca5898a4e4133bbce2ea2315a1916", IsActive.LoginCount));
                    if (logCount <= 10 && logCount > 0 && IsActive.licenceType == 2)
                    {
                        logCount -= 1;
                        IsActive.LoginCount = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", logCount.ToString());
                        rep.Update(IsActive);

                        var EmpName = db.Employee.Where(a => a.IsDeleted == false && a.Id == userIformation.EmployeeId).SingleOrDefault()?.EmployeeNameAr;
                        var CompanyName = db.CompanyInfo.FirstOrDefault().CompanyName;

                        var sett = db.InvoicesSettings.FirstOrDefault();
                        int? year = null;
                        if (sett != null)
                        {

                            var yearId = Convert.ToInt32(db.InvoicesSettings.FirstOrDefault().YearId);
                            if (yearId != 0)
                            {
                                year = Convert.ToInt32(db.Years.FirstOrDefault(a => a.YearId == yearId).YearName);
                            }
                        }
                            globalData.UserID = userIformation.Id;
                        globalData.RememberMe = user.RememberMe;
                        globalData.Password = user.Password;
                        globalData.UserCode = userIformation.Code;
                        globalData.EmployeeId = userIformation.EmployeeId;
                        globalData.Image = userIformation.Image;
                        globalData.LoginName = userIformation.ArbDescription;
                        globalData.EmpName = EmpName;
                        globalData.CompanyName = CompanyName;
                        globalData.Year = year;
                        //var ComID = db.CompanyInfo.FirstOrDefault().Id;
                        //globalData.CompanyID = ComID;
                        globalData.DefaultLanguage = 0;
                        globalData.UserDescription = globalData.PDefaultLanguage ? userIformation.EngDescription : userIformation.ArbDescription;
                        //Users_Branches users_Branches = db.Users_Branches.Where(u => u.UsersId == userIformation.Id && u.IsDefault == true).FirstOrDefault();
                        //Branches branch = db.Branches.Where(b => b.Id == users_Branches.BranchId).FirstOrDefault();
                        //if (branch != null)
                        //{
                        //    globalData.CompanyID = branch.OrganizationId ?? 0;
                        //    globalData.BranchId = branch.Id;

                        //}
                        Session["Message"] = "";
                        //globalData.CompanyID = branch.OrganizationId ?? 0;
                        //globalData.BranchId = (int)BrancheId/* branch.Id*/;
                        //var BrancheName = db.Branches.Where(a => a.IsDeleted == false && a.Id == BrancheId).SingleOrDefault()?.BranchesName;
                        //globalData.BrancheName = BrancheName;
                        //if (BrancheId == 0)
                        //{


                        //    return Redirect("/Login/Index");
                        //}
                    }
                }

                else if (IsActive.LoginCount == null)
                {
                    var CompanyName = "";

                    var EmpName = db.Employee.Where(a => a.IsDeleted == false && a.Id == userIformation.EmployeeId).SingleOrDefault()?.EmployeeNameAr;
                    var Company = db.CompanyInfo.FirstOrDefault();
                    if (Company != null)
                    {
                        CompanyName = Company.CompanyName;
                    }
                    var sett = db.InvoicesSettings.FirstOrDefault();
                    int? year = null;
                    if (sett != null)
                    {

                        var yearId = Convert.ToInt32(db.InvoicesSettings.FirstOrDefault().YearId);
                        if (yearId != 0)
                        {
                            year = Convert.ToInt32(db.Years.FirstOrDefault(a => a.YearId == yearId).YearName);
                        }
                    }
                    globalData.UserID = userIformation.Id;
                    globalData.RememberMe = user.RememberMe;
                    globalData.Password = user.Password;
                    globalData.UserCode = userIformation.Code;
                    globalData.EmployeeId = userIformation.EmployeeId;
                    globalData.Image = userIformation.Image;
                    globalData.LoginName = userIformation.ArbDescription;
                    globalData.EmpName = EmpName;
                    globalData.CompanyName = CompanyName;
                    globalData.Year = year;

                    //var ComID = db.CompanyInfo.FirstOrDefault().Id;
                    //globalData.CompanyID = ComID;
                    globalData.DefaultLanguage = 0;
                    globalData.UserDescription = globalData.PDefaultLanguage ? userIformation.EngDescription : userIformation.ArbDescription;
                    //Users_Branches users_Branches = db.Users_Branches.Where(u => u.UsersId == userIformation.Id && u.IsDefault == true).FirstOrDefault();
                    //Branches branch = db.Branches.Where(b => b.Id == users_Branches.BranchId).FirstOrDefault();
                    //if (branch != null)
                    //{
                    //    globalData.CompanyID = branch.OrganizationId ?? 0;
                    //    globalData.BranchId = branch.Id;

                    //}
                    Session["Message"] = "";
                    //globalData.CompanyID = branch.OrganizationId ?? 0;
                    //globalData.BranchId = (int)BrancheId/* branch.Id*/;
                    //var BrancheName = db.Branches.Where(a => a.IsDeleted == false && a.Id == BrancheId).SingleOrDefault()?.BranchesName;
                    //globalData.BrancheName = BrancheName;
                    //if (BrancheId == 0)
                    //{


                    //    return Redirect("/Login/Index");
                    //}
                }
                else if (userIformation == null)
                {
                    ViewBag.Message = "كلمة المرور أو اسم المستخدم غير صحيح";
                    Session["Message"] = "كلمة المرور أو اسم المستخدم غير صحيح";
                    //return Redirect("/Login/Index");
                    //Message = "User Name not found or wrong password.  Please try again /المستخدم غير موجود او كلمة السر خطأ  .. رجاء اعادة المحاولة";

                }
                else if (userIformation != null && userIformationWithDate == null)
                {
                    ViewBag.Message = "هذا المستخدم تخطى المدة المسموحة لتسجيل دخوله";
                    Session["Message"] = "هذا المستخدم تخطى المدة المسموحة لتسجيل دخوله";
                    //return Redirect("/Login/Index");
                    //Message = "User Name not found or wrong password.  Please try again /المستخدم غير موجود او كلمة السر خطأ  .. رجاء اعادة المحاولة";

                }

                authen.Authenticated = true;
                HelperMethods.globalData = globalData;
                authen.ReturnMessage = Message;
                if (!String.IsNullOrEmpty(Message))
                {
                    ViewBag.ReturnMessage = Message;
                    return View(authen);
                }
                else
                {
                    userIformationWithDate.LastLoginDate = DateTime.Now;
                        db.SaveChanges();
                    
                        //LoggedUser.CreateActionLog(5078, globalData.UserID, "عرض", 0, "Login / تسجيل دخول");
                        return Redirect("/Home/Index");

                }

            }
            else
            {
                       userIformationWithDate.LastLoginDate = DateTime.Now;
                        db.SaveChanges();
                      return Redirect("/Grou/Index");
            }


        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Activation()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Activation(ActivationTbl _Active)
        {
            var MAC = GetMACAddress();
            var ee = CmpositeMacAddressss(MAC);
            var sup = SubStringMacAddress(ee);
            var IsActive = db.ActivationTbl.SingleOrDefault(a => a.productMac == sup);
            var encMac = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", sup);
            var encLoginCount = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", "10");
            string finaleEnc = "";
            string supFinalEnc = "";
            string divideSupFinalEnc = "";
            foreach (var c in encMac)
            {
                int p = (int)c;
                finaleEnc += p.ToString();
            }
            supFinalEnc = finaleEnc.Substring(0, 15);
            divideSupFinalEnc = SplitMacAddressAfterEnc(supFinalEnc);
            if (divideSupFinalEnc == _Active.serialKey)
            {
                if (IsActive != null)
                {
                    IsActive.licenceType = 1;
                    IsActive.LoginCount = null;
                    IsActive.serialKey = _Active.serialKey;
                    rep.Update(IsActive);
                    Session["IsTrial"] = "";
                }
                else
                {
                    _Active.licenceType = 1;

                    _Active.productMac = sup;


                    rep.Insert(_Active);
                }


                //var record = db.City.Max(a => a.Id);
                //LoggedUser.CreateActionLog(1006, globalData.UserID, 2, record, "City / المدن");
                return RedirectToAction("Index");

            }
            else
            {
                Session["SerialNotValid"] = "يوجد خطا فى كود التفعيل";
                return RedirectToAction("Activation");
            }

        }
        [HttpPost]
        public ActionResult ActivationTrial(ActivationTbl _Active)
        {
            var MAC = GetMACAddress();
            var ee = CmpositeMacAddressss(MAC);
            var sup = SubStringMacAddress(ee);
            var encLoginCount = EncryptString("b14ca5898a4e4133bbce2ea2315a1916", "10");
            var IsActive = db.ActivationTbl.SingleOrDefault(a => a.productMac == sup);
            if (IsActive != null)
            {

                //Session["IsExist"] = "لقد اخذت نسختك التجريبية مسبقا";
                return RedirectToAction("Index");
            }
            //var record = db.City.Max(a => a.Id);
            //LoggedUser.CreateActionLog(1006, globalData.UserID, 2, record, "City / المدن");
            else
            {

                _Active.licenceType = 2;
                _Active.LoginCount = encLoginCount;
                _Active.productMac = sup;



                rep.Insert(_Active);
                return RedirectToAction("Index");

            }


        }
        //public JsonResult GetBranchesList(string code)
        //{
        //    if (String.IsNullOrEmpty(code))
        //    {
        //        throw new System.ArgumentNullException(nameof(code));
        //    }
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        db.Configuration.ProxyCreationEnabled = false;
        //        //string DelartypeId = db.Safe.Where(a => a.Id == ID).FirstOrDefault()?.SafeName;
        //        var UserId = db.User.Where(a => a.Code == code && a.IsDeleted == false).Select(a => a.Id).FirstOrDefault();
        //        var Branchess = db.Users_Branches.Where(a => a.UsersId == UserId && a.IsDeleted == false).Select(a => a.BranchId).ToList();



        //        List<Branches> BranchId = db.Branches.Where(a => a.IsDeleted == false && Branchess.Contains(a.Id)).ToList();




        //        return Json(BranchId, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult GetAuthenticate(Users user, int Lang, string returnUrl)
        //{
        //    Authentication authen = new Authentication();
        //    string Message = default(string);
        //    var Encryptedpassword = Cryptography.EncryptPassword(user.Password, null);
        //    var userIformation = db.User.Where(u => u.Code == user.Code && u.Password == Encryptedpassword).FirstOrDefault();

        //    if (userIformation != null)
        //    {
        //        globalData.UserID = userIformation.Id;
        //        globalData.UserCode = userIformation.Code;
        //        globalData.EmployeeId = userIformation.EmployeeId;
        //        globalData.Image = userIformation.Image;
        //        globalData.DefaultLanguage = 0;
        //        globalData.UserDescription = globalData.PDefaultLanguage ? userIformation.EngDescription : userIformation.ArbDescription;
        //        Users_Branches users_Branches = db.Users_Branches.Where(u => u.UserId == userIformation.Id && u.IsDefault == 1).FirstOrDefault();
        //        Branches branch = db.Branches.Where(b => b.Id == users_Branches.BranchId).FirstOrDefault();
        //        if (branch != null)
        //        {
        //            globalData.CompanyID = branch.OrganizationId ?? 0;
        //            globalData.BranchId = branch.Id;

        //        }
        //    }
        //    else
        //    {

        //        return Redirect("/Login/Index");
        //        //Message = "User Name not found or wrong password.  Please try again /المستخدم غير موجود او كلمة السر خطأ  .. رجاء اعادة المحاولة";

        //    }

        //    authen.Authenticated = true;
        //    HelperMethods.globalData = globalData;
        //    authen.ReturnMessage = Message;
        //    if (!String.IsNullOrEmpty(Message))
        //    {
        //        ViewBag.ReturnMessage = Message;
        //        return View(authen);
        //    }
        //    else
        //    {
        //        return Redirect("/Home/Index");

        //    }
        //}


        public class Authentication
        {
            public bool Authenticated { get; set; }
            public string ReturnMessage { get; set; }
            public string ReturnPage { get; set; }
            public int LoginCount { get; set; }
        }
    }
}