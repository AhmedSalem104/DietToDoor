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
    public partial class GetEmpsInformations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object BrancheName;
            object LoginName;

            object EmpName; ;
            object PrintFormat;
            object JobTitle;

            object Department;
            object Status;
            object Query;
            object Path;
            object DataSet;
            object TRXName;

            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                BrancheName = Session["BrancheName"];
                TRXName = Session["TRXName"];
                LoginName = Session["LoginName"];


                PrintFormat = Session["PrintFormat"];
                EmpName = Session["EmpName"];
                JobTitle = Session["JobTitle"];
                Department = Session["Department"];
                Status = Session["Status"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[7] { LoginName,BrancheName,EmpName,PrintFormat,JobTitle,Department,Status };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[7];
                    param[0] = new ReportParameter("LoginName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("EmpName", Convert.ToString(parameter[2]), true);
                    param[3] = new ReportParameter("PrintFormat", Convert.ToString(parameter[3]), true);

                    param[4] = new ReportParameter("JobTitle", Convert.ToString(parameter[4]), true);
                    param[5] = new ReportParameter("Department", Convert.ToString(parameter[5]), true);

                    param[6] = new ReportParameter("Status", Convert.ToString(parameter[6]), true);
                   


                    ReportViewer report = new ReportViewer();
                    ReportViewer24.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer24.LocalReport.DataSources.Add(Rds);
                    ReportViewer24.LocalReport.Refresh();
                    ReportViewer24.LocalReport.SetParameters(param);
                    ReportViewer24.AsyncRendering = false;
                    ReportViewer24.SizeToReportContent = true;
                    ReportViewer24.ZoomMode = ZoomMode.FullPage;


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