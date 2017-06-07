using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_sType))]
    public partial class sType
    {
        public class _sType{
            [Key]
            [DisplayName("細分編號")]
            public int sType_ID { get; set; }
            [DisplayName("細分名稱")]
            public string sType_Name { get; set; }

    } 
    }
}