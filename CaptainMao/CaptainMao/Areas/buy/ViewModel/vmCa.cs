using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.buy.ViewModel
{

    //使用vm 以免陷入循環參考
    public class vm_sType
    {
        public int sType_ID { get; set; }
        public string sType_Name { get; set; }

        //public int Type_ID { get; set; }
    }

    public class vmCaID_typeID_stypeID
    {
        public int? CategoryID { get; set; }
        public int? Type_ID { get; set; }
        public int? sType_ID { get; set; }
    }
    public class vmCa_Mer_stype
    {
        public IEnumerable<Category> _Category { get; set; }

        public Merchandise _Merchandise { get; set; }

        public IEnumerable<CaptainMao.Models.sType> _sType { get; set; }

        [Required(ErrorMessage="至少選一個分類")]
        public string[] sType_ID { get; set; }

    }

    public class vmShoppingCar_Mer {


        [DisplayName("商品編號")]
        public int Merchandise_ID { get; set; }
        [DisplayName("商品名稱")]
        public string Merchandise_Name { get; set; }
        [DisplayName("商品價錢")]
        [DisplayFormat(DataFormatString = "{0:c0}")]
        public decimal Merchandise_Price { get; set; }
        [DisplayName("數量")]
        [Range(1, 100)]
        public int merchandise_Volume { get; set; }
        [DisplayName("商品圖片")]
        public byte[] Merchandise_Photo { get; set; }
        [DisplayName("商店編號")]
        public string Store_ID { get; set; }
        [DisplayName("商店名稱")]
        public string Store_Name { get; set; }
    }
}