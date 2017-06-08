using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(_Type))]
    public partial class Type
    {
        public class _Type
        {
            [DisplayName("分類編號")]
            public int Type_ID { get; set; }
            [DisplayName("分類名稱")]
            public string Type_Name { get; set; }
            [JsonIgnore]

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<sType> sTypes { get; set; }


        }
    }
}