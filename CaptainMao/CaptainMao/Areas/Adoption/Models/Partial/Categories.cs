using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Adoption.Models
{
    [MetadataType(typeof(CategoriesMetadata))]
    public partial class Categories
    {
        public class CategoriesMetadata
        {
            public int CategoryID { get; set; }
            [DisplayName("寵物種類")]
            public string CategoryName { get; set; }
        }
    }
}