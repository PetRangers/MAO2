using CaptainMao.Areas.buy.Models;
using CaptainMao.Areas.buy.ViewModel;
using CaptainMao.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CaptainMao.Models.Category;

namespace CaptainMao.Areas.buy.Controllers
{
    public class zPublicFunctionController : Controller
    {
        ClsBusinessLogic fun = new ClsBusinessLogic();
            /// <summary>
            /// 依照網址判斷傳回對應的商品，呈現在shoppping-index-aside
            /// </summary>
            /// <param name="vm">傳入categoryID or typeID or stypeID</param>
            /// <returns>index-aside.js</returns>
        public ActionResult returnJson_asTypes(vmCaID_typeID_stypeID vm)
        {
            return Json(fun.Logic_Type_selectsType(vm)
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult PixbyID(int id)
        {
            return File(fun.Logic_getMerchandisePhoto(id), "image/jpeg");
        }

        
        public ActionResult returnJson_selectFourStore(int cityID)
        {
            return Json(fun.Logic_GetStore(cityID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult returnJson_selectCitys() {

            return Json(fun.Logic_GetAllCities(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult returnJson_selectMer() {

            return Json(fun.Logic_NewReport(User.Identity.GetUserId()), JsonRequestBehavior.AllowGet);
        }


    }
}