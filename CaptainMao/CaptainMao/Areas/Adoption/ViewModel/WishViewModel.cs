using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaptainMao.Models;
using System.ComponentModel;

namespace CaptainMao.Areas.Adoption.ViewModel
{
    public class WishViewModel
    {
        public IEnumerable<AdpWish> adpwishs { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<City> cities { get; set; }

        [DisplayName("聯絡人")]
        public string NickName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("連絡電話")]
        public string PhoneNumber { get; set; }
    }
}