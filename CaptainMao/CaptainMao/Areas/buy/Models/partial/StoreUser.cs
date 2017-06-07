using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_StoreUser))]
    public partial class StoreUser
    {
        
        public class _StoreUser
        {
            [Key]
            [DisplayName("商店編號")]
            public int StoreID { get; set; }
            [DisplayName("商店名稱")]
            public string StoreName { get; set; }


        }
    }
}