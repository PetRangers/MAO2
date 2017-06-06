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
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.Comment = new HashSet<Comment>();
        }
    
        public int ArticleID { get; set; }
        public int BoardID { get; set; }
        public string PosterID { get; set; }
        public string Title { get; set; }
        public int TitleCategoryID { get; set; }
        public string ContentText { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public Nullable<System.DateTime> LastChDateTime { get; set; }
        public Nullable<int> Number { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Board Board { get; set; }
        public virtual TitleCategories TitleCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
