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
    public partial class ItemsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object UserName;
            object SystemFunctionName;
            object GroupName;
            object CatName;
            object StoreName;
            object Query;
            object Path;
            object DataSet;
            object BrancheName;
            object EmpName;
            object LoginName;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                UserName = Session["UsersId"];
                SystemFunctionName = Session["SystemFunctionId"];
                GroupName = Session["GroupName"];
                CatName = Session["CatName"];
                StoreName = Session["StoreName"];
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
                    object[] parameter = new object[6] { EmpName, BrancheName, LoginName,GroupName,CatName,StoreName };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //ReportViewer1.LocalReport.EnableExternalImages = true;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[6];

                    param[0] = new ReportParameter("EmpName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("LoginName", Convert.ToString(parameter[2]), true);
                    param[3] = new ReportParameter("GroupName", Convert.ToString(parameter[3]), true);

                    param[4] = new ReportParameter("CatName", Convert.ToString(parameter[4]), true);

                    param[5] = new ReportParameter("StoreName", Convert.ToString(parameter[5]), true);


                    ReportViewer report = new ReportViewer();
                    ReportViewer24.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer24.LocalReport.DataSources.Add(Rds);
                    ReportViewer24.LocalReport.Refresh();
                    ReportViewer24.LocalReport.SetParameters(param);
                    ReportViewer24.AsyncRendering = false;
                    ReportViewer24.SizeToReportContent = true;
                    ReportViewer24.ZoomMode = ZoomMode.FullPage;
                    System.Drawing.Printing.PageSettings AlmostA4 = new System.Drawing.Printing.PageSettings();

                    //AlmostA4.PaperSize = new System.Drawing.Printing.PaperSize("CustomType", 17, 12);
                    //ReportViewer1.Width = AlmostA4.PaperSize.Width;
                    //ReportViewer1.Height = AlmostA4.PaperSize.Height;
                    //AlmostA4.Margins.Right = 0;
                    //ReportViewer1.SetPageSettings(AlmostA4);
                    Style s = new Style();
                    s.Width = 20;
                    ReportViewer24.ApplyStyle(s);

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