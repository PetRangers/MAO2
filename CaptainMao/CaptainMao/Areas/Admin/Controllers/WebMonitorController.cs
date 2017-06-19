using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class WebMonitorController : Controller
    {
        MaoEntities db = new MaoEntities();

        // GET: Admin/WebMonitor
        public ActionResult Monitor()
        {
            return View();
        }

        //以下是網站流量相關統計的方法
        //設定監測登入人數的天數
        public const int monitoredDays=30;

        public ActionResult loginCount()
        {
            var logins = db.LoginLogs.Select(l=>l.LoginTime).ToList();
            
            List<int> loginDaysAgo = new List<int>();

            foreach (var login in logins)
            {
                int days = (int)((DateTime.UtcNow - login).TotalDays);
                loginDaysAgo.Add(days);
            }
            
            int[] loginCounts = new int[monitoredDays];
            string[] loginDates = new string[monitoredDays];
            for (int i = 0; i < monitoredDays; i++)
            {
                loginCounts[monitoredDays - i - 1] = loginDaysAgo.Count(x => x == i);
                loginDates[monitoredDays - i - 1] = DateTime.UtcNow.AddDays(-i).ToShortDateString();
            }
            var loginData = new { loginDates, loginCounts};
            
            return Json(loginData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult personLoginCount()
        {
            var logins = (from l in db.LoginLogs
                         where l.LoginTime>DateTime.UtcNow.AddDays(-monitoredDays)
                         group l by l.LoginIP into g
                         select new
                         {
                             user=g.Key,
                             counts = g.Count()
                         }).ToList();

            int[] loginCounts = new int[monitoredDays];
            string[] user = new string[monitoredDays];

            foreach (var l in logins)
            {
                
            }
            
            return Json(logins, JsonRequestBehavior.AllowGet);
        }

    }
}