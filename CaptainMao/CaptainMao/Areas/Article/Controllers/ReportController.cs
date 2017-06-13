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
            //var date=db.Articles.Where(a=>a.CreateDateTime==DateTime.Now.GetDateTimeFormats("2017/1").Count())
            ViewModel.ReportViewModel data = new ViewModel.ReportViewModel();
            data.Category1 = Enumerable.Range(0, 100).OrderBy(a => Guid.NewGuid()).Take(12).ToList();
            data.Category2 = Enumerable.Range(0, 100).OrderBy(a => Guid.NewGuid()).Take(12).ToList();

            return Json(data);
        }
    }
}