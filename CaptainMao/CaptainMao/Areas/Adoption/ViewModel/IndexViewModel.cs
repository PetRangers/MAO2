using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Models;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<CaptainMao.Models.Adoption> adoptions { get; set; }
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<Citys> cities { get; set; }
    }
}