using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_Order))]
    public partial class Order
    {
        public class _Order
        {
            [DisplayName("訂單編號")]
            public int Order_ID { get; set; }
            [DisplayName("帳號")]
            public int user_ID { get; set; }
            [DisplayName("商品數量")]
            public int merchandise_Volume { get; set; }
            [DisplayName("訂單建立時間")]
            public System.DateTime Order_Createdate { get; set; }
            [DisplayName("訂單狀態")]
            public bool Order_Fitness { get; set; }


        }
    }
}