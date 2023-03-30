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
    public partial class GeneralVendorsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            object VendorName;
            object BrancheName;
            object LoginName;
            object Query;
            object Path;
            object DataSet;
            object TRXName;

            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                
                VendorName = Session["VendorName"];
                BrancheName = Session["BrancheName"];
                TRXName = Session["TRXName"];
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
                    object[] parameter = new object[3] { LoginName, BrancheName,VendorName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("LoginName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("VendorName", Convert.ToString(parameter[2]), true);

                    ReportViewer report = new ReportViewer();
                    ReportViewer27.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer27.LocalReport.DataSources.Add(Rds);
                    ReportViewer27.LocalReport.Refresh();
                    ReportViewer27.LocalReport.SetParameters(param);
                    ReportViewer27.AsyncRendering = false;
                    ReportViewer27.SizeToReportContent = true;
                    ReportViewer27.ZoomMode = ZoomMode.FullPage;


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