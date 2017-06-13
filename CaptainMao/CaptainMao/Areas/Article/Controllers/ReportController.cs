using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Article.Controllers
{
    public class ReportController : Controller
    {
        CaptainMao.Models.MaoEntities db = new CaptainMao.Models.MaoEntities();
        // GET: Article/Report
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Report()
        {
            ViewModel.ReportViewModel data = new ViewModel.ReportViewModel();

            List<int> countList1 = new List<int>();
            List<int> countList2 = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                int board1 = db.Articles.Where(a =>a.BoardID==1 && a.CreateDateTime.Month == i).Count();
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
    }
}