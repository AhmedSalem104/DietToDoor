using DataMapping.Entites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPWEB.Reporting.Forms
{
    public partial class PaymentMoneyTRXForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object SafeName;
            object Query;
            object BrancheName;
            object LoginName;
            object Path;
            object DataSet;
            object numConv;
            object PageName;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                SafeName = Session["SafeName"];
                numConv = Session["numConv"];
                PageName = Session["PageName"];
                BrancheName = Session["BrancheName"];
                LoginName = Session["LoginName"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[4] { numConv, PageName,BrancheName,LoginName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("numConv", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("PageName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("BrancheName", Convert.ToString(parameter[2]), true);
                    param[3] = new ReportParameter("LoginName", Convert.ToString(parameter[3]), true);

                    //param[1] = new ReportParameter("ToDate", Convert.ToString(parameter[1]), true);
                    //param[2] = new ReportParameter("SafeName", Convert.ToString(parameter[2]), true);
                    ReportViewer report = new ReportViewer();
                    ReportViewer14.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer14.LocalReport.DataSources.Add(Rds);
                    ReportViewer14.LocalReport.Refresh();
                    ReportViewer14.LocalReport.SetParameters(param);
                    ReportViewer14.AsyncRendering = false;
                    ReportViewer14.SizeToReportContent = true;
                    ReportViewer14.ZoomMode = ZoomMode.FullPage;


                    Session["FromDate"] = null;
                    //Session["LogoImg"] = null;
                    Session["DataSet"] = null;
                    Session["Path"] = null;
                    Session["query"] = null;
                    Session["numConv"] = null;
                    
                }
            }
            else
            {
                return;
            }
        }
    }
}