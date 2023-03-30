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
    public partial class GetAllCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object BrancheName;
            object LoginName;

            object CityName; ;
            object PrintFormat;
            object CustomerName;

            object ClassName;
            object GovernateName;
            object Query;
            object Path;
            object DataSet;
            object TRXName;

            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
               
                BrancheName = Session["BrancheName"];
                
                LoginName = Session["LoginName"];


                PrintFormat = Session["PrintFormat"];
                CityName = Session["CityName"];
                CustomerName = Session["CustomerName"];
                ClassName = Session["ClassName"];
                GovernateName = Session["GovernateName"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[7] { LoginName, BrancheName, CityName, PrintFormat, CustomerName, ClassName, GovernateName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[7];
                    param[0] = new ReportParameter("LoginName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("CityName", Convert.ToString(parameter[2]), true);
                    param[3] = new ReportParameter("PrintFormat", Convert.ToString(parameter[3]), true);

                    param[4] = new ReportParameter("CustomerName", Convert.ToString(parameter[4]), true);
                    param[5] = new ReportParameter("ClassName", Convert.ToString(parameter[5]), true);

                    param[6] = new ReportParameter("GovernateName", Convert.ToString(parameter[6]), true);



                    ReportViewer report = new ReportViewer();
                    ReportViewer26.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer26.LocalReport.DataSources.Add(Rds);
                    ReportViewer26.LocalReport.Refresh();
                    ReportViewer26.LocalReport.SetParameters(param);
                    ReportViewer26.AsyncRendering = false;
                    ReportViewer26.SizeToReportContent = true;
                    ReportViewer26.ZoomMode = ZoomMode.FullPage;


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