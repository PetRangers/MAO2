using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Models
{
    [MetadataType(typeof(CitysMetadata))]
    public partial class Citys
    {
        public class CitysMetadata
        {
            public int CityID { get; set; }
            [DisplayName("居住都市")]
            public string CityName { get; set; }
        }
    }
}