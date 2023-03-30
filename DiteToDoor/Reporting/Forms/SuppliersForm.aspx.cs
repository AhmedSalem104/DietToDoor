using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maintanence.Reporting.Forms
{
    public partial class SuppliersForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindReport();
            }
        }
        private void BindReport()
        {
            try
            {
                var dataSet = Session["DataSet"].ToString();
                var path = Session["Path"].ToString();
                var list = Session["DataResult"];
                var UserName = Session["UserName"];
                var CompanyName = Session["CompanyName"];
                //var BrancheName = Session["BrancheName"];

                object[] parameter = new object[2] { UserName, CompanyName };

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(path);
                ReportDataSource datasource = new ReportDataSource(dataSet, list);

                ReportParameter[] param = new ReportParameter[2];
                param[0] = new ReportParameter("UserName", Convert.ToString(parameter[0]), true);
                param[1] = new ReportParameter("CompanyName", Convert.ToString(parameter[1]), true);
                //param[2] = new ReportParameter("BrancheName", Convert.ToString(parameter[2]), true);

                this.ReportViewer1.LocalReport.SetParameters(param);

                ReportViewer1.Width = 600;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch (Exception)
            {

            }
        }
    }
}