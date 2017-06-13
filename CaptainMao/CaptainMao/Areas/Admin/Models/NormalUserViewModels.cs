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
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "電子郵件(帳號)")]
        [EmailAddress]
        public string UserName { get; set; }

        [Display(Name = "郵件已驗證")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "手機")]
        public string PhoneNumber { get; set; }

        [Display(Name = "手機已驗證")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "啟用雙因素認證")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "帳號鎖定終止時間")]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }

        [Display(Name = "啟用帳號鎖定")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "登入失敗次數")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "暱稱")]
        public string NickName { get; set; }

        [Display(Name = "姓")]
        public string LastName { get; set; }

        [Display(Name = "名")]
        public string FirstName { get; set; }

        [Display(Name = "登入次數")]
        public Nullable<int> LoginCount { get; set; }

        [Display(Name = "上次登入時間")]
        public  Nullable<DateTime> LoginTime { get; set; }

        [Display(Name = "經驗值")]
        public Nullable<int> Experience { get; set; }

        [Display(Name = "註冊日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime DateRegistered { get; set; }

        [Display(Name = "照片")]
        public string Photo { get; set; }
    }



}