using CaptainMao.Areas.buy.Models;
using CaptainMao.Filters;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            ViewBag.city = fun.Logic_GetAllCities();
            return View();
        }



        [ChildActionOnly]
        public ActionResult Aside() {
            return PartialView();
        }

        [AuthorizeMao(Roles ="Normal")]
        public async Task<ActionResult> CreateOrder(string name, int FourStore)
        {
            string session = "login" ;
            if (Session["user_identity"] != null) {
                session = Session["user_identity"].ToString();
            }
            fun.Logic_CreateOrder(User.Identity.GetUserId(), name, FourStore, session);

            var service = new EmailService();
            IdentityMessage message = new IdentityMessage { Body = "fuckfuckfuck", Destination = User.Identity.GetUserName(), Subject = "fuckfuckfuck" };
            await service.SendAsync(message);



            return RedirectToAction("Index","Shopping");
        }


    }
}