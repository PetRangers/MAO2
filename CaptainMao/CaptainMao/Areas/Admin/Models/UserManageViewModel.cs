using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Admin.Models
{
    public class NormalUserViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "姓")]
        public string LastName { get; set; }

        [Display(Name = "名")]
        public string FirstName { get; set; }

        [Display(Name = "電子郵件(帳號)")]
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Display(Name = "手機")]
        public string PhoneNumber { get; set; }

        [Display(Name = "暱稱")]
        public string NickName { get; set; }

        [Display(Name = "註冊日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime DateRegistered { get; set; }

        [Display(Name = "照片")]
        public string Photo { get; set; }
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