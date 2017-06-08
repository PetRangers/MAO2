using CaptainMao.Areas.buy.Models;
using CaptainMao.Areas.buy.ViewModel;
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
        ClsBusinessLogic fun = new ClsBusinessLogic();  //使用商業邏輯層
       // GET: buy/Store

        public ActionResult Index()
        {
            if (Session["user_identity"] != null)   //判斷是否有登入
            { return View(fun.Logic_SelectStoreMerch((string)Session["user_identity"])); }
            return RedirectToAction("index", "Login");  //沒登入則回去登入首頁
        }

        [ChildActionOnly]
        public ActionResult Aside() {
            return View();
        }

        [HttpGet]
        public ActionResult Create() {
            if (Session["user_identity"] == null)
            { return RedirectToAction("index", "Login"); }
            vmCa_Mer_stype vm = new vmCa_Mer_stype();
            ViewBag.Form = "Create";
            return View(fun.Logic_returnNewCa_Mer(vm));
        }

        [HttpPost]
        public ActionResult Create(vmCa_Mer_stype vm, HttpPostedFileBase photo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(fun.Logic_returnNewCa_Mer(vm));
                }
                if (photo != null)
                {  /*轉圖片*/
                    vm._Merchandise.Merchandise_Photo =fun.Logic_PhotoToByte(photo);
                }
                vm._Merchandise.Store_ID = (string)Session["user_identity"];
                fun.Logic_MerchandiseSave(vm);
                
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewBag.Message= ex.Message;
                ViewBag.Form = "Create";
                return View(fun.Logic_returnNewCa_Mer(vm));
            }
        }
        [HttpGet]
        public ActionResult Edit(int Merchandise_ID) {
            //            ViewBag.notMer
            try
            {
                if (Session["user_identity"] == null)
                { return RedirectToAction("index", "Login"); }
                ViewBag.Form = "Edit";

                return View("Create", fun.Logic_returnEdit_CaMerSty(Merchandise_ID, (string)Session["user_identity"]));
            }
            catch (MissingFieldException)
            {
                ViewBag.notMer = true;
                return View("Create");
            }
            catch(Exception ex) {
                ViewBag.Message = ex.Message;
                ViewBag.Form = "Edit";
                return View("Create");
            }
        }
        [HttpPost]
        public ActionResult Edit(vmCa_Mer_stype vm, HttpPostedFileBase photo) {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Form = "Edit";
                    return View("Create", fun.Logic_returnEdit_CaMerSty(vm._Merchandise.Merchandise_ID, (string)Session["user_identity"]));
                }
                if (photo != null)
                {  /*轉圖片*/
                    vm._Merchandise.Merchandise_Photo = fun.Logic_PhotoToByte(photo);
                }
                vm._Merchandise.Store_ID = (string)Session["user_identity"];
                fun.Logic_MerchandiseEdit(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Form = "Edit";
                return View("Create",vm);
            }
        }
        public ActionResult Delete(int Merchandise_ID) {
            fun.Logic_MerchandiseDelete(Merchandise_ID);
            return RedirectToAction("Index");
        }
    }
}