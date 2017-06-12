using CaptainMao.Areas.buy.ViewModel;
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

        /*尋找商品*/
        public IEnumerable<Merchandise> Logic_SelectMerchandise(vmCaID_typeID_stypeID vm)
        {
            IEnumerable<Merchandise> selectMer = null;
            //依照網址去找尋所需要呈現的商品
            if (vm.sType_ID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.sType_ID == vm.sType_ID));
            }
            else if (vm.Type_ID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.Type_ID == vm.Type_ID));
            }
            else if (vm.CategoryID.HasValue)
            {
                selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises;
            }
            else {
                selectMer = _merchandise.GetAll();
            }
            return selectMer;
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
            var mer = _Category.GetbyID((int)vm.CategoryID).Merchandises;
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
            shoppingcart sh = new shoppingcart();
            sh.DateCreated = DateTime.UtcNow;
            sh.Merchandise_ID = Merchandise_ID;
            sh.merchandise_Volume = 1;
            sh.userID = user_identity;
            _shoppingcart.Create(sh);
        }
        /*列出購物車*/
        public IEnumerable<vmShoppingCar_Mer> Logic_GetShoppingCart(string identityID) {
            List<vmShoppingCar_Mer> vmlist = new List<vmShoppingCar_Mer>();
            var shopping =  DB.shoppingcarts.Where(c => c.userID.Equals(identityID));

            foreach (var _sh in shopping)
            {
                vmShoppingCar_Mer vm = new vmShoppingCar_Mer();
                vm.Merchandise_ID = _sh.Merchandise_ID;
                vm.Merchandise_Name = _sh.Merchandise.Merchandise_Name;
                vm.Merchandise_Price = _sh.Merchandise.Merchandise_Price;
                vm.merchandise_Volume = _sh.merchandise_Volume;
                vm.Merchandise_Photo = _sh.Merchandise.Merchandise_Photo;
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
        public void Logic_DeleteShoppingCart(int cartID)
        {
            _shoppingcart.DeletebyID(cartID);
        }
        /*回傳所有超商資料*/
        public IEnumerable<CaptainMao.Models.FourStore> Logic_GetStore(string city) {
            return DB.FourStores.Where(c=>c.BranchAddress.Contains(city));
        }

        public IEnumerable<CaptainMao.Models.City> Logic_GetAllCity() {
            return DB.Cities;
        }

    }
}