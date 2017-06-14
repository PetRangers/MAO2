using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Areas.Adoption.ViewModel;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        CaptainMao.Models.MaoEntities db = new CaptainMao.Models.MaoEntities();
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ArticleReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetArticleReport()
        {
            CaptainMao.Areas.Article.ViewModel.ReportViewModel data = new CaptainMao.Areas.Article.ViewModel.ReportViewModel();

            List<int> countList1 = new List<int>();
            List<int> countList2 = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                int board1 = db.Articles.Where(a => a.BoardID == 1 && a.CreateDateTime.Month == i).Count();
                int board2 = db.Articles.Where(a => a.BoardID == 2 && a.CreateDateTime.Month == i).Count();
                countList1.Add(board1);
                countList2.Add(board2);
            }
            data.Category1 = countList1;
            data.Category2 = countList2;
            return Json(data);
        }
        public ActionResult Aside()
        {
            return PartialView();
        }

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

t
        
    }
}