using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Models;

using CaptainMao.Areas.buy.Models;
using CaptainMao.Areas.buy.ViewModel;
using CaptainMao.Filters;
using Microsoft.AspNet.Identity;

namespace CaptainMao.Areas.buy.Controllers
{
    public class ShoppingController : Controller
    {
        ClsBusinessLogic fun = new ClsBusinessLogic();
        
        public ActionResult Index(vmCaID_typeID_stypeID vm)
        {
            if (Session["user_identity"] == null) {
                Session["user_identity"] = Guid.NewGuid().ToString();
            }
            IEnumerable<Merchandise> selectMer =fun.Logic_SelectMerchandise(vm);
            return View(selectMer);
        }

        public ActionResult Index_I(vmCaID_typeID_stypeID vm)
        {
            if (Session["user_identity"] == null)
            {
                Session["user_identity"] = Guid.NewGuid().ToString();
            }
            IEnumerable<Merchandise> selectMer = fun.Logic_SelectMerchandise(vm);
            return View(selectMer);
        }


        [ChildActionOnly]
        public ActionResult Aside()
        {
            return PartialView(fun.Logic_GetAllCategory());
        }

        public ActionResult About(int Merchandise_ID) {

            return View(fun.Logic_GetAllMerchandise(Merchandise_ID));
        }






    }
}