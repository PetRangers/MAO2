using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(TitleCategories))]
    public partial class TitleCategories
    {
        public class TitleCategoriesMetadata
        {
            [DisplayName("標題分類")]
            public int TitleCategoryID { get; set; }
            public string TitleCategoryName { get; set; }
        }
    }
}