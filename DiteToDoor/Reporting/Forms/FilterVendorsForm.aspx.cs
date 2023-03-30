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
    public partial class FilterVendorsForm : System.Web.UI.Page
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

                var username = Session["UserName"];
                var companyname = Session["CompanyName"];



                var dataSet = Session["DataSet"].ToString();
                var path = Session["Path"].ToString();
                var list = Session["DataResult"];

                //var SDate = Session["StartDate"];
                //var Edate = Session["EndDate"];

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(path);
                ReportDataSource datasource = new ReportDataSource(dataSet, list);

                ReportParameter p1 = new ReportParameter("CompanyName", companyname.ToString());
                ReportParameter p2 = new ReportParameter("UserName", username.ToString());

                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

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