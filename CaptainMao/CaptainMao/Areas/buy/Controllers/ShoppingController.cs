using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Models;

using CaptainMao.Areas.buy.Models;
using CaptainMao.Areas.buy.ViewModel;

namespace CaptainMao.Areas.buy.Controllers
{
    public class ShoppingController : Controller
    {
        ClsBusinessLogic fun = new ClsBusinessLogic();
        public ActionResult Index(vmCaID_typeID_stypeID vm)
        {
            IEnumerable<Merchandise> selectMer =fun.Logic_SelectMerchandise(vm);
            return View(selectMer);
        }

        [ChildActionOnly]
        public ActionResult Aside()
        {
            return View(fun.Logic_GetAllCategory());
        }



    }
}