using DataMapping.Entites;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreSystem.Reporting.Forms
{
    public partial class GeneralForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object FromDate;
            object ToDate;
            object BrancheName;
            object LoginName;
            object Query;
            object Path;
            object DataSet;
            object TRXName;
            object QRCode;
            //object OrganizationLogo;
            if (Session["DataSet"] != null && Session["query"] != null)
            {
                FromDate = Session["FromDate"];
                ToDate = Session["ToDate"];
                BrancheName = Session["BrancheName"];
                TRXName = Session["TRXName"];
                LoginName = Session["LoginName"];
                QRCode = Session["QRText"];
                //OrganizationLogo = Session["LogoImg"];
                DataSet = Session["DataSet"];
                Path = Session["Path"];
                Query = Session["query"];
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var queryStr = Query;
                    string PathStr = Convert.ToString(Path);
                    string DataSetStr = Convert.ToString(DataSet);
                    object[] parameter = new object[3] { LoginName, BrancheName, QRCode };
                    //string imagePath = db.Organizations.Where(a => a.IsDeleted == false && a.IsActive == true).FirstOrDefault().LogoLink;
                    //string imgPath = new Uri(Server.MapPath(imagePath)).AbsoluteUri;

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("LoginName", Convert.ToString(parameter[0]), true);
                    param[1] = new ReportParameter("BrancheName", Convert.ToString(parameter[1]), true);
                    param[2] = new ReportParameter("QRCode", Convert.ToString(parameter[2]), true);

                    ReportViewer report = new ReportViewer();
                    ReportViewer7.LocalReport.ReportPath = Server.MapPath(PathStr);
                    ReportDataSource Rds = new ReportDataSource(DataSetStr, queryStr);
                    ReportViewer7.LocalReport.DataSources.Add(Rds);
                    ReportViewer7.LocalReport.Refresh();
                    ReportViewer7.LocalReport.EnableExternalImages = true;
                    QRCoder.QRCodeGenerator qRCodeGenerator =new QRCoder.QRCodeGenerator();
                    QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(QRCode.ToString(),QRCoder.QRCodeGenerator.ECCLevel.Q);
                    QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
                    Bitmap bmp = qRCode.GetGraphic(7);
                    using (MemoryStream ms = new MemoryStream()) {
                        bmp.Save(ms, ImageFormat.Bmp);
                        //StoreSystem.Reporting.DS.GeneralDs generalDs = new DS.GeneralDs();
                        //StoreSystem.Reporting.DS.GeneralDs.QRCodeRow qRCodeRow = generalDs.QRCode.NewQRCodeRow();
                        //qRCodeRow.Image = ms.ToArray();
                        //generalDs.QRCode.AddQRCodeRow(qRCodeRow);
                        //ReportDataSource Rdss = new ReportDataSource();
                        //Rdss.Name = "ReportData";
                       
                        //Rdss.Value = generalDs.QRCode;

                        //ReportViewer7.LocalReport.DataSources.Add(Rdss);

                    }
                        ReportViewer7.LocalReport.SetParameters(param);
                    ReportViewer7.AsyncRendering = false;
                    ReportViewer7.SizeToReportContent = true;
                    ReportViewer7.ZoomMode = ZoomMode.FullPage;
                   
                    
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