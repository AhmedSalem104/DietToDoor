using DataMapping.Entites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maintanence.Reporting.Forms
{
    public partial class Get_Car_Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            object Query;
          
            object Path;
            object DataSet;
         
            object LoginName;
            object MaintananceManager;
            object CompanyManager;
            object SupervisorManager;
            object Text;

            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
               
                LoginName = Session["LoginName"];
                MaintananceManager = Session["MaintananceManager"];
                CompanyManager = Session["CompanyManager"];
                SupervisorManager = Session["SupervisorManager"];
                Text = Session["Text"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[5] {  LoginName, MaintananceManager, CompanyManager, SupervisorManager ,Text};
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[5];
                   

                    //param[3] = new ReportParameter("BrancheName", Convert.ToString(parameter[3]), true);
                    param[0] = new ReportParameter("LoginName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("MaintananceManager", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("CompanyManager", Convert.ToString(parameter[2]), true);
                    param[3] = new ReportParameter("SupervisorManager", Convert.ToString(parameter[3]), true);
                    param[4] = new ReportParameter("Text", Convert.ToString(parameter[4]), true);






                    ReportViewer report = new ReportViewer();
                    ReportViewer60.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer60.LocalReport.DataSources.Add(Rds);
                    ReportViewer60.LocalReport.Refresh();
                    ReportViewer60.LocalReport.SetParameters(param);
                    ReportViewer60.AsyncRendering = false;
                    ReportViewer60.SizeToReportContent = true;
                    ReportViewer60.ZoomMode = ZoomMode.FullPage;
                    System.Drawing.Printing.PageSettings AlmostA4 = new System.Drawing.Printing.PageSettings();

                    //AlmostA4.PaperSize = new System.Drawing.Printing.PaperSize("CustomType", 17, 12);
                    //ReportViewer1.Width = AlmostA4.PaperSize.Width;
                    //ReportViewer1.Height = AlmostA4.PaperSize.Height;
                    //AlmostA4.Margins.Right = 0;
                    //ReportViewer1.SetPageSettings(AlmostA4);
                    Style s = new Style();
                    s.Width = 20;
                    ReportViewer60.ApplyStyle(s);

                    //Session["FromDate"] = null;
                    ////Session["LogoImg"] = null;
                    //Session["DataSet"] = null;
                    //Session["Path"] = null;
                    //Session["query"] = null;
                }
            }
            else
            {
                return;
            }

        }
    }
}