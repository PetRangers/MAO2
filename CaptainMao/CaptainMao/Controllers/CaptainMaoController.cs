using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Controllers
{
    public class CaptainMaoController : Controller
    {
        // GET: CaptainMao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult Aside()
        {
            return View();
        }


    }
}