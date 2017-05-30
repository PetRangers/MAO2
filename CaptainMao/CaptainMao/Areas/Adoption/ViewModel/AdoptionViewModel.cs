using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Areas.Adoption.Models;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class AdoptionViewModel
    {
        public Categories category { get; set; }
        public Models.Adoption adoption { get; set; }
        public Citys city { get; set; }
    }
}