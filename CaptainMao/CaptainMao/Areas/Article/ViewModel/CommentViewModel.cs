using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Article.Models
{
    public class CommentViewModel
    {
        public IEnumerable<CaptainMao.Models.Article> article { get; set; }
        public IEnumerable<CaptainMao.Models.Comment> comment { get; set; }
    }
}