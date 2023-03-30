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
    public partial class CashingMoneyTRXX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object SafeName;
            object Query;
            object Path;
            object DataSet;
            object numConv;
            object PageName;
            object BrancheName;
            object EmpName;
            object LoginName;

            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                SafeName = Session["SafeName"];
                numConv = Session["numConv"];
                PageName = Session["PageName"];
                BrancheName = Session["BrancheName"];
                EmpName = Session["EmpName"];
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
                    object[] parameter = new object[5] { numConv, PageName,BrancheName,LoginName, EmpName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[5];
                    param[0] = new ReportParameter("numConv", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("PageName", Convert.ToString(parameter[1]), true);
                   
                    param[3] = new ReportParameter("BrancheName", Convert.ToString(parameter[3]), true);
                    param[4] = new ReportParameter("LoginName", Convert.ToString(parameter[4]), true);
                    param[2] = new ReportParameter("EmpName", Convert.ToString(parameter[2]), true);

                    //param[1] = new ReportParameter("ToDate", Convert.ToString(parameter[1]), true);
                    //param[2] = new ReportParameter("SafeName", Convert.ToString(parameter[2]), true);
                    ReportViewer report = new ReportViewer();
                    ReportViewer15.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer15.LocalReport.DataSources.Add(Rds);
                    ReportViewer15.LocalReport.Refresh();
                    ReportViewer15.LocalReport.SetParameters(param);
                    ReportViewer15.AsyncRendering = false;
                    ReportViewer15.SizeToReportContent = true;
                    ReportViewer15.ZoomMode = ZoomMode.FullPage;


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