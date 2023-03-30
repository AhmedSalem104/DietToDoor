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
    public partial class ItemCardGeneralForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object SafeName;
            object Query;
            object Path;
            object DataSet;
            object TRXName;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                SafeName = Session["SafeName"];
                TRXName = Session["TRXName"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[4] { FromDate, ToDate, SafeName, TRXName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    //ReportParameter[] param = new ReportParameter[3];
                    //param[0] = new ReportParameter("FromDate", Convert.ToString(parameter[0]), true);
                    //param[1] = new ReportParameter("ToDate", Convert.ToString(parameter[1]), true);
                    //param[2] = new ReportParameter("SafeName", Convert.ToString(parameter[2]), true);
                    ReportViewer report = new ReportViewer();
                    ReportViewer13.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer13.LocalReport.DataSources.Add(Rds);
                    ReportViewer13.LocalReport.Refresh();
                    //ReportViewer1.LocalReport.SetParameters(param);
                    ReportViewer13.AsyncRendering = false;
                    ReportViewer13.SizeToReportContent = true;
                    ReportViewer13.ZoomMode = ZoomMode.FullPage;


                    Session["FromDate"] = null;
                    //Session["LogoImg"] = null;
                    Session["DataSet"] = null;
                    Session["Path"] = null;
                    Session["query"] = null;
                }
            }
            else
            {
                return;
            }
        }
    }
}