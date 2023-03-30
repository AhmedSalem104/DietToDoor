using ERPWeb.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class View_AuthorizationController : AuthorizeAttribute
    {
        // GET: View_Authorization
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string returnUrl = HttpContext.Current.Request.Url.AbsolutePath;

            /*User is Authenticated*/
            if (HelperMethods.globalData.UserID != 0)
            {
                string[] route = HttpContext.Current.Request.Path.Split('/').Where(elem => !string.IsNullOrEmpty(elem)).ToArray();
                string PageName = "";
                string ActionName = "";
                int count = route.Count();
                if (count != 0)
                {
                    PageName = route[0].Trim().ToLower();

                }

                if (count > 1)
                {
                    ActionName = route[1].Trim().ToLower();
                    //string RouteID = route[2].Trim().ToLower();
                }

                if (route.Length > 0 && PageName != "home")
                {
                    if (ActionName == "create" || ActionName == "edit" || ActionName == "delete" || ActionName == "")
                    {
                        if (!ERPWeb.Models.SecurityRoles.LoggedUser.InRole(PageName, ActionName))
                        {
                            //    /*User hasn't Permission*/
                            filterContext.Result = new RedirectResult("/AppError/UnauthorisedAccess", false);
                        }
                    }

                }

            }
            /*User isn't Authenticated*/
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Index", false);
            }
        }

    }
}