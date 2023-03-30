using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Reports
{
    public interface IBasicReport
    {
        byte[] CurrencyReport(string Code, string NameEn, string NameAr, int reportType);
    }
}
