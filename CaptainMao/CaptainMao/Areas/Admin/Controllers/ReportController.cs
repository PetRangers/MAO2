using CaptainMao.Areas.Adoption.ViewModel;
using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        MaoEntities db = new MaoEntities();

        // GET: Admin/Report
        public ActionResult AdoptionReport()
        {
            return View();
        }
        public ActionResult GetAdoptionReport()
        {
            AdpReportViewModel data = new AdpReportViewModel();

            List<AdpReport> adps = new List<AdpReport>();
            int Total = db.Adoptions.Count();
            int CateCount = db.Categories.Count();
            for (int i = 1; i <= CateCount; i++)
            {
                AdpReport adp = new AdpReport();
                adp.CategoryName = db.Categories.Where(a => a.CategoryID == i).Select(a => a.CategoryName).First();
                double count = db.Adoptions.Where(a => a.CategoryID == i).Count();
                adp.Share = count / Total;
                adps.Add(adp);
            }
            data.AdpReports = adps;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}