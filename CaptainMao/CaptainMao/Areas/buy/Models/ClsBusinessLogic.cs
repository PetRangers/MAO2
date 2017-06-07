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

        /*尋找商品*/
        public IEnumerable<Merchandise> Logic_SelectMerchandise(vmCaID_stypeID vm)
        {
            IEnumerable<Merchandise> selectMer = null;
            int selectX = 0;
            if (vm.CategoryID.HasValue)
                selectX++;
            if (vm.Type_ID.HasValue)
                selectX++;
            if (vm.sType_ID.HasValue)
            {
                selectX += 2;
            }
            switch (selectX)
            {
                case 1:
                    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises;
                    break;
                case 2:
                    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.Type_ID == vm.Type_ID));
                    break;
                case 3:
                    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.sType_ID == vm.sType_ID));
                    break;
                default:
                    selectMer = _merchandise.GetAll();
                    break;
            }



            //if (vm.sType_ID.HasValue)
            //{   //利用小分類搜尋
            //    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s => s.sTypes.Any(ss => ss.sType_ID == vm.sType_ID&&ss.Type_ID==vm.Type_ID));
            //}
            //else if (vm.Type_ID.HasValue)
            //{   //利用大分類搜尋，因大分類在小分類內，故較雜
            //    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises.Where(s=>s.sTypes.Any(ss=>ss.Type_ID==vm.Type_ID));

            //}
            //else if (vm.CategoryID.HasValue)
            //{   //利用寵物分類搜尋
            //    selectMer = _Category.GetbyID((int)vm.CategoryID).Merchandises;
            //}
            //else
            //{
            //    selectMer = _merchandise.GetAll();
            //}
            return selectMer;
        }
        /*大分類回傳*/
        public IEnumerable<Category> Logic_GetAllCategory() {
            return _Category.GetAll();
        }
        /*小分類回傳*/
        public IEnumerable<vmType_sType> Logic_Type_selectsType(vmCaID_stypeID vm)
        {
            //搜尋所有該寵物分類的商品
            var mer = _Category.GetbyID((int)vm.CategoryID).Merchandises;
            List<vmType_sType> vmlist = new List<vmType_sType>();
             
            //利用搜尋出來的商品去找他所有的小分類
            foreach (var _mer in mer)
            {   //將小分類搜尋出來
               var sty = _mer.sTypes.OrderBy(y => y.Type_ID).
                    Where(y=>y.Type_ID==vm.Type_ID).
                    Select(y=>new vmType_sType {sType_ID= y.sType_ID,sType_Name= y.sType_Name});

                //在該商品的多個小分類中尋找
                foreach (var _sty in sty)
                {
                    //判斷在集合內是否有相同的結果
                    if (!vmlist.Any(s=>s.sType_Name.Contains(_sty.sType_Name))) {
                        vmlist.Add(_sty);
                    }
                }
                //if (!vmlist.Contains(sty)) {
                //    vmlist.Add(sty);
                //}
               
            }

            return vmlist;
        }

        public IEnumerable<CaptainMao.Models.sType> Logic_GetsType()
        {
            return _sType.GetAll().OrderBy(x=>x.Type_ID);
        }

        public void MerchandiseSave(ViewModel.vmCa_Mer vm) {
            Merchandise mer = new CaptainMao.Models.Merchandise();
            mer.CategoryID =  vm._Merchandise.CategoryID;
            
            mer.Merchandise_Description = vm._Merchandise.Merchandise_Description;
            mer.Merchandise_Fitness = true;
            mer.Merchandise_Name = vm._Merchandise.Merchandise_Name;
            mer.Merchandise_Photo = vm._Merchandise.Merchandise_Photo;
            mer.Merchandise_Price = vm._Merchandise.Merchandise_Price;
            mer.Store_ID = vm._Merchandise.Store_ID;
            mer.Merchandise_Creatdate = DateTime.UtcNow;
            //尋找剛剛創出的ID
            int Merchandise_ID=  MerSaveReturnID(mer);
            for (int x= 0;x< vm.sType_ID.Length;x++) {
                DB.InsertToMerchandise_Type_View(Merchandise_ID, Convert.ToInt32(vm.sType_ID[x]));
            }
        }


        private int MerSaveReturnID(Merchandise mer) {
            _merchandise.Create(mer);
            return mer.Merchandise_ID;
        }

         public IEnumerable<vmCa_Type> Logic_Category_selectType(int CategoryID)
        {
            //var type = _Category.GetbyID(CategoryID).sTypes;

            //List<vmCa_Type> vmLis = new List<vmCa_Type>();
            //string x = null;
            //foreach (var s in type)
            //{
            //    if (x != s.Type.Type_Name)
            //    {
            //        vmCa_Type _vm = new vmCa_Type();
            //        _vm.Type_ID = s.Type_ID;
            //        _vm.Type_Name = s.Type.Type_Name;
            //        vmLis.Add(_vm);
            //        x = s.Type.Type_Name;
            //    }
            //}
            return null;
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


        public IEnumerable<CaptainMao.Models.Type> Logic_GetAllType(){
            return _Type.GetAll();
            }
        





    }
}