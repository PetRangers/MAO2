using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Adoption.Models
{
    [MetadataType(typeof(AdoptionMetadata))]
    public partial class Adoption
    {
        public class AdoptionMetadata
        {
            public int AdoptionID { get; set; }
            [DisplayName("寵物名字")]
            public string Name { get; set; }
            [DisplayName("性別")]
            public string Sex { get; set; }
            [DisplayName("寵物種類")]
            public int CategoryID { get; set; }
            [DisplayName("體型")]
            public string Build { get; set; }
            [DisplayName("年紀")]
            public string Age { get; set; }
            [DisplayName("居住都市")]
            public int CityID { get; set; }
            [DisplayName("毛色")]
            public string Hair { get; set; }
            [DisplayName("描述")]
            public string Description { get; set; }
            public DateTime PostDate { get; set; }
            public byte[] BytesImage { get; set; }
            [DisplayName("寵物照片")]
            public string PetImage { get; set; }
            public bool DelCheck { get; set; }
            public Nullable<int> RegistrationUserID { get; set; }

            public virtual Categories Categories { get; set; }
            public virtual Citys Citys { get; set; }

        }
    }
}