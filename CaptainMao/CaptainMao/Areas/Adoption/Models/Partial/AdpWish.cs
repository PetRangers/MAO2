using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(AdpWishMetadata))]
    public partial class AdpWish
    {
        public class AdpWishMetadata
        {
            [DisplayName("心願編號")]
            public int WishID { get; set; }

            [DisplayName("聯絡人")]
            public string UserID { get; set; }

            [DisplayName("性別")]
            public string Sex { get; set; }

            [DisplayName("寵物種類")]
            [Required(ErrorMessage = "請選擇")]
            public int CategoryID { get; set; }

            [DisplayName("體型")]
            public string Build { get; set; }

            [DisplayName("年紀")]
            public string Age { get; set; }

            [DisplayName("居住都市")]
            [Required(ErrorMessage = "請選擇")]
            public int CityID { get; set; }

            [DisplayName("毛色")]
            public string Hair { get; set; }

            [DisplayName("最後更新日期")]
            [DataType(DataType.Date)]
            public System.DateTime PostDate { get; set; }
        }
    }
}