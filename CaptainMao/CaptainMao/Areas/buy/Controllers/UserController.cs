using CaptainMao.Areas.buy.Models;
using CaptainMao.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.buy.Controllers
{
    public class UserController : Controller
    {
        ClsBusinessLogic fun = new ClsBusinessLogic();  //使用商業邏輯層
        [AuthorizeMao(Roles = "Normal")]
        // GET: buy/User
        public ActionResult Index()
        {
            return View();
        }

    }
}