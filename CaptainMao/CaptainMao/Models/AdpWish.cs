//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaptainMao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdpWish
    {
        public int WishID { get; set; }
        public string UserID { get; set; }
        public string Sex { get; set; }
        public int CategoryID { get; set; }
        public string Build { get; set; }
        public string Age { get; set; }
        public int CityID { get; set; }
        public string Hair { get; set; }
        public System.DateTime PostDate { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Citys Citys { get; set; }
    }
}
