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
    public partial class GeneralFormRequestLimit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            object FromDate;
            object ToDate;
            object SafeName;
            object StoreName;
            object ItemName;
            object EmpName;
            object BrancheName;
            object GroupName;
            object Query;
            object Path;
            object DataSet;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                SafeName = Session["SafeName"];
                StoreName = Session["StoreName"];
                ItemName = Session["ItemName"];
                EmpName = Session["EmpName"];
                BrancheName = Session["BrancheName"];
                GroupName = Session["GroupName"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[2] { EmpName, BrancheName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[2];
                    //param[0] = new ReportParameter("FromDate", Convert.ToString(parameter[0]), true);
                    //param[1] = new ReportParameter("ToDate", Convert.ToString(parameter[1]), true);
                    param[0] = new ReportParameter("EmpName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    ReportViewer report = new ReportViewer();
                    ReportViewer9.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer9.LocalReport.DataSources.Add(Rds);
                    ReportViewer9.LocalReport.Refresh();
                    //ReportViewer1.LocalReport.SetParameters(param);
                    ReportViewer9.LocalReport.SetParameters(param);
                    ReportViewer9.AsyncRendering = false;
                    ReportViewer9.SizeToReportContent = true;
                    ReportViewer9.ZoomMode = ZoomMode.FullPage;



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