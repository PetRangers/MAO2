using CaptainMao.Areas.buy.Models;
using CaptainMao.Filters;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.buy.Controllers
{
    public class ShoppingCartController : Controller
    {
        ClsBusinessLogic fun = new ClsBusinessLogic();

        // GET: buy/ShoppingCart
        public ActionResult Index()
        {
            ViewBag.city = fun.Logic_GetAllCity();
            return View();
        }



        [ChildActionOnly]
        public ActionResult Aside() {
            return PartialView();
        }
        [HttpPost]
        [AuthorizeMao(Roles ="Normal")]
        public ActionResult CreateOrder(string name, int FourStore)
        {
            string session ="1";
            if (Session["user_identity"] != null) {
                session = Session["user_identity"].ToString();
            }
            fun.Logic_CreateOrder(User.Identity.GetUserId(), name, FourStore, session);

            return View();
        }
    }
}