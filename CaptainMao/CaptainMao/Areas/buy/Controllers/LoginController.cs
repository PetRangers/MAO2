using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.buy.Controllers
{
    public class LoginController : Controller
    {
        // GET: buy/Login
        public ActionResult Index()
        {
              return View();
        }
        public ActionResult NormalUser()
        {
            Session["user_identity"] = "Normal";
            return RedirectToAction("index", "Shopping");
        }
        public ActionResult StoreUser()
        {
            Session["user_identity"] = "d6927155-c35b-4810-a830-e9de6cd9cf0d";
            return RedirectToAction("index","Store");
        }

    }
}