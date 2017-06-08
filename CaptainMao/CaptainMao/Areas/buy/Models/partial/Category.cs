using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_Category))]
    public partial class Category
    {
        public class _Category
        {
            [Key]
            [DisplayName("寵物分類編號")]
            public int CategoryID { get; set; }

            [DisplayName("寵物分類")]
            public string CategoryName { get; set; }

        }
    }
}