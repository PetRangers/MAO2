using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(ArticleMetadata))]
    public partial class Article
    {
        public class ArticleMetadata
        {
            public int ArticleID { get; set; }

            [Required(ErrorMessage ="請選擇{0}")]
            [DisplayName("動物種類")]
            public int BoardID { get; set; }

            [DisplayName("發文者")]
            public Nullable<int> PosterID { get; set; }

            [Required(ErrorMessage = "請輸入{0}")]
            [DisplayName("標題")]
            public string Title { get; set; }

            [Required(ErrorMessage = "請選擇{0}")]
            [DisplayName("標題分類")]
            public int TitleCategoryID { get; set; }

            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage = "請輸入{0}")]
            [DisplayName("文章內容")]
            public string ContentText { get; set; }

            [DisplayName("發文時間")]
            public Nullable<System.DateTime> CreateDateTime { get; set; }

            [DisplayName("最後發表時間")]
            public Nullable<System.DateTime> LastChDateTime { get; set; }

            [DisplayName("瀏覽數")]
            public Nullable<int> Number { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}