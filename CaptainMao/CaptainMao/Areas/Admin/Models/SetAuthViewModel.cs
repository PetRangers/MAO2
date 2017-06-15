using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Admin.Models
{
    public class SetAuthViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "電子郵件(帳號)")]
        [EmailAddress]
        public string UserName { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "經驗值")]
        public Nullable<int> Experience { get; set; }

        [Display(Name = "網站管理者")]
        public bool IsAdmin { get; set; }

        [Display(Name = "討論版版主")]
        public bool IsMaster { get; set; }

        //[Display(Name = "管理版面")]
        //public string MasterOfBoards { get; set; }

        [Display(Name = "商店會員")]
        public bool IsStore { get; set; }

        [Display(Name = "一般會員")]
        public bool IsNormal { get; set; }

        [Display(Name = "停權中")]
        public bool IsInactivated { get; set; }

        [Display(Name = "狗版版主")]
        public bool IsBoardDogMaster { get; set; }

        [Display(Name = "貓版版主")]
        public bool IsBoardCatMaster { get; set; }
    }
}