using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class AdpReportViewModel
    {
        public List<AdpReport> AdpReports { get; set; }
    }

    public class AdpReport
    {
        public string CategoryName { get; set; }
        public double Share { get; set; }
    }
}