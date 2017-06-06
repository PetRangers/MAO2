using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(CommentMetadata))]
    public partial class Comment
    {
        public class CommentMetadata
        {
            public int ArticleID { get; set; }

            [DisplayName("回覆數")]
            public int CommentID { get; set; }

            [DisplayName("發表人")]
            public int PosterID { get; set; }

            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage ="請輸入{0}")]
            [DisplayName("回覆內容")]
            public string ContentText { get; set; }

            [DisplayName("發表時間")]
            public Nullable<System.DateTime> NewDateTime { get; set; }
        }
    }
}