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
    
    public partial class Merchandise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Merchandise()
        {
            this.shoppingcarts = new HashSet<shoppingcart>();
            this.sTypes = new HashSet<sType>();
            this.Merchandise_Order_View = new HashSet<Merchandise_Order_View>();
        }
    
        public int Merchandise_ID { get; set; }
        public string Merchandise_Name { get; set; }
        public decimal Merchandise_Price { get; set; }
        public byte[] Merchandise_Photo { get; set; }
        public string Merchandise_Photo_Address { get; set; }
        public string Merchandise_Description { get; set; }
        public bool Merchandise_Fitness { get; set; }
        public System.DateTime Merchandise_Creatdate { get; set; }
        public Nullable<System.DateTime> Merchandiser_Editdata { get; set; }
        public string Store_ID { get; set; }
        public int CategoryID { get; set; }
 //       public string Merchandise_Photo_Address { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shoppingcart> shoppingcarts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sType> sTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Merchandise_Order_View> Merchandise_Order_View { get; set; }
    }
}
