using Microsoft.Reporting.WebForms;
using Report.DataSets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Reports
{
    public class BasicReport : IBasicReport
    {
        DataSet _dataSet = null;
        ReportParameter _reportParameter = null;
        List<ReportParameter> _reportParameters = null;
        public BasicReport()
        {

        }

        public byte[] CurrencyReport(string Code, string NameEn, string NameAr, int reportType)
        {
            try
            {
                IEnumerable<Tuple<string, string, string, string, string, string, decimal>> customerDueInfo = _customerService.CustomerCategoryWiseDueRpt(concernID, CustomerId, reportType, DueType);

                BasicDataSet.dtcurrency dt = new BasicDataSet.dtCustomerDataTable();
                _dataSet = new DataSet();

                foreach (var grd in customerDueInfo)
                {
                    dt.Rows.Add(grd.Item1, grd.Item2, grd.Item3, grd.Item4, grd.Item5, grd.Item6, grd.Item7);
                }

                dt.TableName = "dtCustomer";
                _dataSet.Tables.Add(dt);

                GetCommonParameters(userName, concernID);
                return ReportBase.GenerateBasicReport(_dataSet, _reportParameters, "rptCustomer.rdlc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
