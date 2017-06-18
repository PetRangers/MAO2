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
            //string[] xAxis = new string[]{"a", "b", "c", "d", "e", "f" };
            ViewBag.xAxis[0] = "a";
            ViewBag.xAxis[1] = "b";
            ViewBag.xAxis[2] = "c";
            ViewBag.xAxis[3] = "d";
            ViewBag.xAxis[4] = "e";
            ViewBag.xAxis[5] = "f";

            //int[] yAxis = new int[]{2, 4, 6, 7, 5, 1 };
            ViewBag.yAxis[0] = 1;
            ViewBag.yAxis[1] = 2;
            ViewBag.yAxis[2] = 3;
            ViewBag.yAxis[3] = 4;
            ViewBag.yAxis[4] = 5;
            ViewBag.yAxis[5] = 6;


            return View();
        }
    }
}