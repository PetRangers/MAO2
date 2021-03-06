﻿using CaptainMao.Areas.buy.ViewModel;
using CaptainMao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.buy.Models
{
    public class ClsBusinessLogic
    {
        IMao<Merchandise> _merchandise = new ClsMao<Merchandise>();
        global::CaptainMao.Models.MaoEntities DB = new MaoEntities();
        IMao<Category> _Category = new ClsMao<Category>();
        IMao<CaptainMao.Models.Type> _Type = new ClsMao<CaptainMao.Models.Type>();
        IMao<sType> _sType = new ClsMao<sType>();
        IMao<StoreUser> _store = new ClsMao<StoreUser>();
        IMao<shoppingcart> _shoppingcart = new ClsMao<shoppingcart>();
        IMao<Merchandise_Order_View> _merchOrder = new ClsMao<Merchandise_Order_View>();
        IMao<Order> _order = new ClsMao<Order>();

        /*尋找商品*/
        public IEnumerable<Merchandise> Logic_SelectMerchandise(vmCaID_typeID_stypeID vm)
        {
            IEnumerable<Merchandise> selectMer = null;
            //依照網址去找尋所需要呈現的商品
            if (vm.sType_ID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.sType_ID == vm.sType_ID)&&s.Merchandise_Fitness==true);
            }
            else if (vm.Type_ID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.Type_ID == vm.Type_ID)&&s.Merchandise_Fitness==true);
            }
            else if (vm.CategoryID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(x=>x.Merchandise_Fitness==true);
            }
            else {
                selectMer = _merchandise.GetAll().Where(x=>x.Merchandise_Fitness==true);
            }
            return selectMer;
        }

        public IEnumerable<Merchandise> Logic_SeachMerchandise(string seach) {
            var x = _merchandise.GetAll().Where(c => c.Merchandise_Name.Contains(seach));
            return x;
        }
        /*寵物分類回傳*/
        public IEnumerable<Category> Logic_GetAllCategory() {
            return _Category.GetAll();
        }

        public Merchandise Logic_GetAllMerchandise(int Merchandise_ID) {
            return _merchandise.GetbyID(Merchandise_ID);
        }
        /*依照該類別目前商品有的小分類回傳*/
        public IEnumerable<vm_sType> Logic_Type_selectsType(vmCaID_typeID_stypeID vm)
        {
            //搜尋所有該寵物分類的商品
            var mer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s=>s.Merchandise_Fitness==true);
            List<vm_sType> vmlist = new List<vm_sType>();
             
            //利用搜尋出來的商品去找他所有的小分類
            foreach (var _mer in mer)
            {   //將小分類搜尋出來
               var sty = _mer.sTypes.OrderBy(y => y.Type_ID).
                    Where(y=>y.Type_ID==vm.Type_ID).
                    Select(y=>new vm_sType {sType_ID= y.sType_ID,sType_Name= y.sType_Name});

                //在該商品的多個小分類中尋找
                foreach (var _sty in sty)
                {
                    //判斷在集合內是否有相同的結果
                    if (!vmlist.Any(s=>s.sType_Name.Contains(_sty.sType_Name))) {
                        vmlist.Add(_sty);
                    }
                }
            }
            return vmlist;
        }
        /*所有小分類回傳*/
        public IEnumerable<CaptainMao.Models.sType> Logic_GetsType()
        {
            return _sType.GetAll().OrderBy(x=>x.Type_ID);
        }
        /*商品儲存*/
        public void Logic_MerchandiseSave(ViewModel.vmCa_Mer_stype vm) {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    vm._Merchandise.Merchandise_Creatdate = DateTime.UtcNow;
                    int Merchandise_ID = MerSaveReturnID(vm._Merchandise);
                    /*使用預存程式儲存*/
                    for (int x = 0; x < vm.sType_ID.Length; x++)
                    {
                        DB.InsertToMerchandise_Type_View(Merchandise_ID, Convert.ToInt32(vm.sType_ID[x]));
                    }
                    transaction.Commit();
                }
                catch{
                    transaction.Rollback();
                }
                
            }
        }
        /*尋找創出的ID*/
        private int MerSaveReturnID(Merchandise mer) {
            _merchandise.Create(mer);
            return mer.Merchandise_ID;
        }

        /*商品修改*/
        public string Logic_MerchandiseEdit(vmCa_Mer_stype vm)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {

                    vm._Merchandise.Merchandiser_Editdata = DateTime.UtcNow;
                    _merchandise.Edit(vm._Merchandise);
                    DB.DeleteToMerchandise_Type_View(vm._Merchandise.Merchandise_ID);
                    /*使用預存程式儲存*/
                    for (int x = 0; x < vm.sType_ID.Length; x++)
                    {
                        DB.InsertToMerchandise_Type_View(vm._Merchandise.Merchandise_ID, 
                            Convert.ToInt32(vm.sType_ID[x]));
                    }
                    transaction.Commit();
                    return "修改成功";

                //catch(Exception ex)
                //{
                //    transaction.Rollback();
                //    return ex.Message;
                //}

            }
        }
        //取出圖片
        public byte[] Logic_getMerchandisePhoto(int num)
        {
            return _merchandise.GetbyID(num).Merchandise_Photo;
        }

        public void Logic_MerchandiseEdit2(Merchandise vm) {
            var mer = _merchandise.GetbyID(vm.Merchandise_ID);
            mer.Merchandiser_Editdata = DateTime.UtcNow;
            mer.Merchandise_Fitness = vm.Merchandise_Fitness;
            mer.Merchandise_Name = vm.Merchandise_Name;
            mer.Merchandise_Price = vm.Merchandise_Price;
            _merchandise.Edit(mer);
        }


        //根據storeID去找Merchandises
        public IEnumerable<Merchandise> Logic_SelectStoreMerch(string id) {
            return DB.Merchandises.Where(x=>x.Store_ID ==id);
        }

        //存入圖片 photo:從前端得到的 x:存入的byte[]欄位
        public byte[] Logic_PhotoToByte(HttpPostedFileBase photo)
        {
            byte[] byteImg = new byte[photo.ContentLength];
            photo.InputStream.Read(byteImg, 0, photo.ContentLength);
            return byteImg;
        }
        /*傳入值給vmCa_Mer*/
        public vmCa_Mer_stype Logic_returnNewCa_Mer(vmCa_Mer_stype vm) {
            vm._Category = Logic_GetAllCategory();
            vm._Merchandise = new Merchandise();
            vm._sType = Logic_GetsType();
            vm.sType_ID = vm.sType_ID == null ? new string[] { } : vm.sType_ID;
            return vm;
        }
        /*商店編輯*/
        public vmCa_Mer_stype Logic_returnEdit_CaMerSty(int Merchandise_ID,string store_ID) {
            vmCa_Mer_stype vm = new vmCa_Mer_stype();
            Logic_returnNewCa_Mer(vm);
            vm._Merchandise = _merchandise.GetbyID(Merchandise_ID);
            if (vm._Merchandise.Store_ID != store_ID) {
                throw new MissingFieldException();
            }
            vm.sType_ID = vm._Merchandise.sTypes.Select(s => s.sType_ID.ToString()).ToArray();
            return vm;
        }
        /*商品刪除*/
        public void Logic_MerchandiseDelete(int Merchandise_ID) {
            DB.DeleteToMerchandise_Type_View(Merchandise_ID);
            _merchandise.DeletebyID(Merchandise_ID);
        }
        /*新增至購物車*/
        public void Logic_AddShopping(string user_identity, int Merchandise_ID) {
            DB.AddToCartMerchandise_Type_View(Merchandise_ID, user_identity);
            //shoppingcart sh = new shoppingcart();
            //sh.DateCreated = DateTime.UtcNow;
            //sh.Merchandise_ID = Merchandise_ID;
            //sh.merchandise_Volume = 1;
            //sh.userID = user_identity;
            //_shoppingcart.Create(sh);
        }
        /*列出購物車*/
        public IEnumerable<vmShoppingCar_Mer> Logic_GetShoppingCart(string identityID,string loginID="login") {
            List<vmShoppingCar_Mer> vmlist = new List<vmShoppingCar_Mer>();
            var shopping =  DB.shoppingcarts.Where(c => c.userID.Equals(identityID)||c.userID.Equals(loginID));

            foreach (var _sh in shopping)
            {
                vmShoppingCar_Mer vm = new vmShoppingCar_Mer();
                vm.Merchandise_ID = _sh.Merchandise_ID;
                vm.Merchandise_Name = _sh.Merchandise.Merchandise_Name;
                vm.Merchandise_Price = _sh.Merchandise.Merchandise_Price;
                vm.merchandise_Volume = _sh.merchandise_Volume;
                vm.Merchandise_Photo = _sh.Merchandise.Merchandise_Photo;
                vm.Merchandise_Photo_Address = _sh.Merchandise.Merchandise_Photo_Address;
                vm.cartID = _sh.cartID;
                vm.Store_ID = _sh.Merchandise.Store_ID;
                vm.Store_Name = DB.AspNetUsers.Where(c => c.Id == _sh.Merchandise.Store_ID).Select(c => c.StoreInfo.StoreName).First();
                vmlist.Add(vm);
            }
            return vmlist;
        }
        /*修改購物車內容*/
        public void Logic_PutShoppingCart(vmShoppingCar_Mer vm,string identityID)
        {
            shoppingcart _shopp = new shoppingcart();
            _shopp.Merchandise_ID = vm.Merchandise_ID;
            _shopp.merchandise_Volume = vm.merchandise_Volume;
            _shopp.userID = identityID;
            _shopp.cartID = vm.cartID;
            _shopp.DateCreated = DateTime.UtcNow;
            _shoppingcart.Edit(_shopp);
        }
        /*取消商品*/
        public void Logic_DeleteShoppingCart(int cartID, string identityID, string loginID="login")
        {
            var mer= DB.shoppingcarts.Where(c => c.userID == identityID || c.userID==loginID);
            
            DB.shoppingcarts.Remove(mer.Where(c => c.cartID == cartID).First());
            DB.SaveChanges();
        }
        /*回傳所有超商資料*/
        public IEnumerable<vmFourStore> Logic_GetStore(int cityID) {
           var city = DB.Cities.Find(cityID).CityName;
            return DB.FourStores.Where(c=>c.Branch.Contains(city)).
                Select(c=>new vmFourStore {Compete= c.Compete ,BranchAddress= c.BranchAddress,BranchID= c.BranchID});
        }
        public IEnumerable<CaptainMao.Models.City> Logic_GetAllCities() {
            return DB.Cities;
        }

        public bool Logic_shoppingHaveEvery(string Session, string UserID) {
            var x = DB.shoppingcarts.Where(s => s.userID == Session || s.userID == UserID);
            try
            {
                x.First();
                return true;
            }
            catch {
                return false;
            }           
            
        }


        private int CreateOrder(Order order) {
             _order.Create(order);
            return order.Order_ID;
        }
        /*後登入時*/
        public void Logic_CreateOrder(string UserID,  string name, int FourStore, string session ) {

            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    Order order = new Order();
                    order.DeliveryLocation = FourStore;
                    order.DeliveryName = name;
                    order.Order_Fitness = true;
                    order.Order_Createdate = DateTime.UtcNow;
                    order.user_ID = UserID;
                    int OrderID = CreateOrder(order);

                    var shoppingcart = DB.shoppingcarts.Where(s => s.userID.Equals(session) || s.userID.Equals(UserID));
                    foreach (var shop in shoppingcart)
                    {
                        Merchandise_Order_View mer = new Merchandise_Order_View();
                        mer.Merchandise_ID = shop.Merchandise_ID;
                        mer.merchandise_Volume = shop.merchandise_Volume;
                        mer.Order_ID = OrderID;
                        _merchOrder.Create(mer);
                        DB.shoppingcarts.Remove(shop);
                    }
                    DB.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public IEnumerable<vmNewOrder> Logic_NewOrder(string StoreID) {
            List<vmNewOrder> NewOlist = new List<vmNewOrder>();
            //找出有包含商家的訂單
            var storeMer = DB.Orders.Where(s => s.Merchandise_Order_View.Any(x => x.Merchandise.Store_ID == StoreID));

            foreach(var _storeMer in storeMer) {

                vmNewOrder NewO = new vmNewOrder();
                NewO.BranchAddress = _storeMer.FourStore.BranchAddress;
                NewO.DeliveryName = _storeMer.DeliveryName;
                NewO.Order_Createdate =  _storeMer.Order_Createdate;
                NewO.Order_Fitness = _storeMer.Order_Fitness;
                NewO.Order_ID = _storeMer.Order_ID;
                NewO.user_ID = _storeMer.AspNetUser.FirstName +"**";

                var _storeM = _storeMer.Merchandise_Order_View;
                List<vmNewOrderMer> _merlist = new List<vmNewOrderMer>();
                foreach (var _store in _storeM) {
                    if (_store.Merchandise.Store_ID == StoreID) { //因訂單內還會有其他商家的商品故再判斷一次
                        vmNewOrderMer _mer = new vmNewOrderMer();
                        _mer.Merchandise_ID = _store.Merchandise_ID;
                        _mer.Merchandise_Name = _store.Merchandise.Merchandise_Name;
                        _mer.merchandise_Volume = _store.merchandise_Volume;
                        _mer.Merchandise_Price = _store.Merchandise.Merchandise_Price * _mer.merchandise_Volume;
                        _merlist.Add(_mer);
                    }
                }
                NewO.mer = _merlist;
                NewOlist.Add(NewO);
            }

            return NewOlist;
        }


        public AspNetUser Logic_ReUser(string User) {
            return DB.AspNetUsers.Where(c => c.Email == User).First() ;
        }

        public IEnumerable<vmNewReport> Logic_NewReport(string StoreID) {
            List<vmNewReport> vmlist = new List<vmNewReport>() ;
            //找出所有商家的訂單
            var storeMer = DB.Orders.Where(s => s.Merchandise_Order_View.Any(x => x.Merchandise.Store_ID == StoreID));
            
            foreach (var store in storeMer) {//每筆的訂單
                foreach (var _store in store.Merchandise_Order_View) { //訂單內的明細
                    if (_store.Merchandise.Store_ID == StoreID)
                    {  //因訂單內還會有其他商家的商品故再判斷一次
                        if (!vmlist.Any(xxx => xxx.Merchandise_Name.Contains(_store.Merchandise.Merchandise_Name)))
                        {
                            vmNewReport vm = new vmNewReport();
                            vm.merchandise_Volume = _store.merchandise_Volume;
                            vm.Merchandise_Name = _store.Merchandise.Merchandise_Name;
                            vmlist.Add(vm);
                        }
                        else {
                            var vm = vmlist.Where(x=>x.Merchandise_Name ==_store.Merchandise.Merchandise_Name).First();
                            vmlist.Remove(vm);
                            vm.merchandise_Volume += _store.merchandise_Volume;
                            vmlist.Add(vm);
                        }
                    }

                }
            }

            return vmlist;
        }

        
    }
}