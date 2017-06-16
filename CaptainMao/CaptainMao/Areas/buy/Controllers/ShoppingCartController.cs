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

            //var nameEm = fun.Logic_ReUser(User.Identity.GetUserName());
            var nameEm = User.Identity.GetUserName();
            string emailContent =
                "<h3>" +nameEm + "您好</h3>" +
                "<p>您已在毛孩隊長購買商品，請在留意貨品出貨日期，謝謝!</p>";

            var service = new EmailService();
            IdentityMessage message = new IdentityMessage { Body = emailContent, Destination = User.Identity.GetUserName(),
                Subject = "毛孩隊長購物商城-成功購物通知" };
            await service.SendAsync(message);
            TempData["ok"] = "購買成功！";
            return RedirectToAction("Index","Shopping");
        }


    }
}