using CaptainMao.Areas.buy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaptainMao.Areas.buy.ViewModel;


namespace CaptainMao.Areas.buy.Controllers
{
    public class PublicAPIController : ApiController
    {
         
        ClsBusinessLogic fun = new ClsBusinessLogic();
        //查詢訂單
        public IEnumerable<vmShoppingCar_Mer> GetShoppingCart()
        {
            //string id = User.Identity.GetUserId() != null ? User.Identity.GetUserId() : (string)Session["user_identity"];
            string id = "6d25c244-4906-4edf-af59-0b86b044be88";
            return fun.Logic_getShoppingCart(id);
        }
        //public IEnumerable<string> GetShoppingCart()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //新增訂單
        public void PostShoppingCart() {

        }
        //修改訂單
        public void PutShoppingCart(vmShoppingCar_Mer vm) {
            string id = "6d25c244-4906-4edf-af59-0b86b044be88"  ;
            fun.Logic_putShoppingCart(vm, id);

        }
        //刪除項目
        public void DeleteShoppingCart(int id) {

        }


    }
}
