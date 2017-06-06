using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Models;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class AdoptionViewModel
    {
        public Categories category { get; set; }
        public CaptainMao.Models.Adoption adoption { get; set; }
        public Citys city { get; set; }
    }
}