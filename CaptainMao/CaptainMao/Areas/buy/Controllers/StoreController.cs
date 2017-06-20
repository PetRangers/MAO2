using CaptainMao.Areas.buy.Models;
using CaptainMao.Areas.buy.ViewModel;
using CaptainMao.Filters;
using CaptainMao.Models;
using Microsoft.AspNet.Identity;
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
       [AuthorizeMao(Roles = "Store")]
        public ActionResult Index()
        {

             return View(fun.Logic_SelectStoreMerch(User.Identity.GetUserId())); 
        }

        [ChildActionOnly]
        public ActionResult Aside() {
            return PartialView();
        }

        [AuthorizeMao(Roles = "Store")]
        [HttpGet]
        public ActionResult Create() {
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
                vm._Merchandise.Store_ID = User.Identity.GetUserId();
                fun.Logic_MerchandiseSave(vm);
                TempData["ok"] = "建立成功";
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                ViewBag.Message= ex.Message;
                ViewBag.Form = "Create";
                return View(fun.Logic_returnNewCa_Mer(vm));
            }
        }
        [AuthorizeMao(Roles = "Store")]
        [HttpGet]
        public ActionResult Edit(int Merchandise_ID) {
            //            ViewBag.notMer
            try
            {
                ViewBag.Form = "Edit";
                return View("Create", fun.Logic_returnEdit_CaMerSty(Merchandise_ID, User.Identity.GetUserId()));
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
                    return View("Create", fun.Logic_returnEdit_CaMerSty(vm._Merchandise.Merchandise_ID,
                        User.Identity.GetUserId()));
                }
                if (photo != null)
                {  /*轉圖片*/
                    vm._Merchandise.Merchandise_Photo = fun.Logic_PhotoToByte(photo);
                }
                vm._Merchandise.Store_ID = User.Identity.GetUserId();
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

        [HttpPost]
        public ActionResult Edit2(Merchandise vm) {
             fun.Logic_MerchandiseEdit2(vm);
            return RedirectToAction("Index");
        }


        [AuthorizeMao(Roles = "Store")]
        public ActionResult Delete(int Merchandise_ID) {
            fun.Logic_MerchandiseDelete(Merchandise_ID);
            return RedirectToAction("Index");
        }

        [AuthorizeMao(Roles = "Store")]
        public ActionResult NewOrder() {

            return View(fun.Logic_NewOrder(User.Identity.GetUserId()));
        }

        [AuthorizeMao(Roles = "Store")]
        public ActionResult Report()
        {
            return View(fun.Logic_NewReport(User.Identity.GetUserId()));
        }
             
    }
}