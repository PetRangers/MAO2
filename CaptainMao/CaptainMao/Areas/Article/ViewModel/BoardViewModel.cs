using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CaptainMao.Models;

namespace CaptainMao.Areas.Article.Models
{
    public class BoardViewModel
    {
        public IEnumerable<CaptainMao.Models.Board> board { get; set; }
        public IEnumerable<CaptainMao.Models.Article> article { get; set; }
    }
}