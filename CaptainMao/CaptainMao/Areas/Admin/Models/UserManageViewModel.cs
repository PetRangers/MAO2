using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Admin.Models
{
    public class NormalUserViewModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public System.DateTime DateRegistered { get; set; }
        public byte[] Photo { get; set; }
    }

    public class NormalUserDetailViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<int> LoginCount { get; set; }
        public Nullable<int> Experience { get; set; }
        public System.DateTime DateRegistered { get; set; }
        public byte[] Photo { get; set; }
    }

}