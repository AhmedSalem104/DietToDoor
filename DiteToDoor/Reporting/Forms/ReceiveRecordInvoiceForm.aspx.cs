using DataMapping.Entites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreSystem.Reporting.Forms
{
    public partial class ReceiveRecordInvoiceForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
            object Query;
            object Path;
            object DataSet;
            object CompanyName;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
               
                CompanyName = Session["CompanyName"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[1] { CompanyName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[1];
                    //param[0] = new ReportParameter("FromDate", Convert.ToString(parameter[0]), true);
                    //param[1] = new ReportParameter("ToDate", Convert.ToString(parameter[1]), true);
                    param[0] = new ReportParameter("CompanyName", Convert.ToString(parameter[0]), true);
                    
                    ReportViewer report = new ReportViewer();
                    ReportViewer5.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer5.LocalReport.DataSources.Add(Rds);
                    ReportViewer5.LocalReport.Refresh();
                    //ReportViewer1.LocalReport.SetParameters(param);
                    ReportViewer5.LocalReport.SetParameters(param);
                    ReportViewer5.AsyncRendering = false;
                    ReportViewer5.SizeToReportContent = true;
                    ReportViewer5.ZoomMode = ZoomMode.FullPage;



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