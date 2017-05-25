using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Article.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article/Article
        public ActionResult Index()
        {
            return View();
        }
    }
}