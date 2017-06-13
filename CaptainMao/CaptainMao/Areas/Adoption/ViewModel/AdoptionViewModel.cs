using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Models;
using System.ComponentModel;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class AdoptionViewModel
    {
        public Category category { get; set; }
        public CaptainMao.Models.Adoption adoption { get; set; }
        public City city { get; set; }
        
        [DisplayName("聯絡人")]
        public string NickName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("連絡電話")]
        public string PhoneNumber { get; set; }
    }
}