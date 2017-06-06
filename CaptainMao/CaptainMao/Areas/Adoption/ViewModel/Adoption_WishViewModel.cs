using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Models;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class Adoption_WishViewModel
    {
        public IEnumerable<CaptainMao.Models.Adoption> adoptions { get; set; }

        public IEnumerable<AdpWish> wishs { get; set; }
    }
}