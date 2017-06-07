using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_merchandise))]
    public partial class Merchandise
    {

        public class _merchandise
        {

            [Key]
            [DisplayName("商品編號")]
            public int Merchandise_ID { get; set; }
            [DisplayName("商品名稱")]
            [Required(ErrorMessage = "請輸入名稱")]
            [StringLength(50, ErrorMessage = "請勿輸入超過50個字")]
            public string Merchandise_Name { get; set; }




            [DisplayName("價錢")]
            [DisplayFormat(DataFormatString = "{0:c0}")]
            [Required(ErrorMessage = "請輸入金額")]
            public decimal Merchandise_Price { get; set; }

            [DisplayName("商品圖片")]
            public byte[] Merchandise_Photo { get; set; }

            [DisplayName("商品簡介")]
            [DataType(DataType.MultilineText)]
            public string Merchandise_Description { get; set; }
            
            [DisplayName("商品狀態")]
            public bool Merchandise_Fitness { get; set; }
            [DisplayName("商品刊登日期")]
            
            public System.DateTime Merchandise_Creatdate { get; set; }
            [DisplayName("商品修改日期")]
            public Nullable<System.DateTime> Merchandiser_Editdata { get; set; }

        }
    }
}