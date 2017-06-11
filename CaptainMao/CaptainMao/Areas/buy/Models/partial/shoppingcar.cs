using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models.partial
{
    [MetadataType(typeof(_shoppingcar))]
    public partial class shoppingcar
    {
        public class _shoppingcar {

            [DisplayName("商品編號")]
            public int Merchandise_ID { get; set; }
            [DisplayName("數量")]
            [Range(1, 100)]
            public int merchandise_Volume { get; set; }


        }
    }
}