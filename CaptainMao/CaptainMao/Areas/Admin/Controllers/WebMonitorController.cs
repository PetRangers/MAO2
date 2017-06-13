using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class WebMonitorController : Controller
    {
        // GET: Admin/WebMonitor
        public ActionResult Monitor()
        {
            return View();
        }
    }
}