using CaptainMao.Areas.buy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaptainMao.Areas.buy.ViewModel;
using Microsoft.AspNet.Identity;
using System.Web;

namespace CaptainMao.Areas.buy.Controllers
{
    public class PublicAPIController : ApiController
    {
         
        ClsBusinessLogic fun = new ClsBusinessLogic();
        //查詢訂單
        [HttpGet]
        public IEnumerable<vmShoppingCar_Mer> GetShoppingCart()
        {
              //string id = User.Identity.GetUserId() != null ? User.Identity.GetUserId() : (string)HttpContext.Current.Session["user_identity"];
            string id = "6d25c244-4906-4edf-af59-0b86b044be88";
            return fun.Logic_GetShoppingCart(id);
        }
        [HttpPost]
        //新增訂單
        public void PostShoppingCart(int Merchandise_ID) {
            //string name = User.Identity.GetUserId() != null ? User.Identity.GetUserId() : (string)HttpContext.Current.Session["user_identity"];
            string id = "6d25c244-4906-4edf-af59-0b86b044be88";
            fun.Logic_AddShopping(id, Merchandise_ID);
        }
        //修改訂單
        [HttpPut]
        public void PutShoppingCart(vmShoppingCar_Mer vm) {
            string id = "6d25c244-4906-4edf-af59-0b86b044be88"  ;
            fun.Logic_PutShoppingCart(vm, id);
        }
        [HttpDelete]
        //刪除項目
        public void DeleteShoppingCart(int id) {
            fun.Logic_DeleteShoppingCart(id);
        }

    }
}
