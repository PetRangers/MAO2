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
            return View();
        }



        [ChildActionOnly]
        public ActionResult Aside() {
            return PartialView();
        }

        [AuthorizeMao]
        public ActionResult CreateOrder()
        {
            if (Session["user_identity"]!=null) {
            }
            return View();
        }
    }
}