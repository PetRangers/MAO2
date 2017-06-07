using CaptainMao.Areas.buy.Models;
using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CaptainMao.Models.sType;

namespace CaptainMao.Areas.buy.Controllers
{
    public class StoreController : Controller
    {
        IMao<CaptainMao.Models.Type> _type = new ClsMao<CaptainMao.Models.Type>();

        ClsBusinessLogic fun = new ClsBusinessLogic();
       // GET: buy/Store

        public ActionResult Index()
        {
            if (Session["user_identity"] != null)
            {
                return View(fun.Logic_SelectStoreMerch((string)Session["user_identity"]));
            }
            else {
                return RedirectToAction("index", "Login");
            }
        }

        [ChildActionOnly]
        public ActionResult Aside() {
            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            if (Session["user_identity"] == null)
            {
                return RedirectToAction("index", "Login");
            }

            ViewModel.vmCa_Mer vm = new ViewModel.vmCa_Mer();
            vm._Category = fun.Logic_GetAllCategory();
            vm._sType = fun.Logic_GetsType();
            vm.sType_ID = new string[] { };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(ViewModel.vmCa_Mer vm, HttpPostedFileBase photo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    vm._Category = fun.Logic_GetAllCategory();
                    vm._sType = fun.Logic_GetsType();
                    vm.sType_ID = vm.sType_ID == null ? new string[] { } : vm.sType_ID;
                    
                    //    ViewBag.sType_ID = new string[] { };
                    //    ViewBag.sType_IDError = "請選擇一個以上的分類";
                    //}
                    
                    return View(vm);
                }
                /*轉圖片*/
                if (photo != null)
                {
                    vm._Merchandise.Merchandise_Photo =fun.Logic_PhotoToByte(photo);
                }

                vm._Merchandise.Store_ID = (string)Session["user_identity"];
                fun.MerchandiseSave(vm);

                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewBag.Message= ex.Message;
                vm._Category = fun.Logic_GetAllCategory();
                vm._sType = fun.Logic_GetsType();
                return View(vm);
            }


        }


        public ActionResult Edite() {
            return View();
        }

    }
}