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
            var allUserCount = db.AspNetUsers.Count();

            var groupedLogins = db.LoginLogs.Select(l=>l).GroupBy(l=>l.UserId).ToList();
                           

            int highFreqUsers = 0;
            int intermediateFreqUsers = 0;
            int lowFreqUsers = 0;
            int inactiveUsers = 0;

            foreach (var l in groupedLogins)
            {
                if (l.Count() >= 10)
                {
                    highFreqUsers++;
                }
                else if (l.Count() >= 4)
                {
                    intermediateFreqUsers++;
                }
                else
                {
                    lowFreqUsers++;
                }
            }

            inactiveUsers = allUserCount - highFreqUsers - intermediateFreqUsers - lowFreqUsers;
            string[] userCategories = {"高頻使用者(當月登入10次以上)", "中頻使用者(當月登入4至9次)", "低頻使用者(當月登入1至3次)", "不活躍使用者(當月無登入紀錄)" };
            int[] userCounts ={ highFreqUsers, intermediateFreqUsers, lowFreqUsers, inactiveUsers };

            var userAnalysisResult = new { userCategories, userCounts };

            return Json(userAnalysisResult, JsonRequestBehavior.AllowGet);

        }
    }
}