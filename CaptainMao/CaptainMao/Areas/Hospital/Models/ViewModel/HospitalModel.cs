using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Hospital.Models.ViewModel
{
    //[MetadataType(typeof(Hospital))]
    public class HospitalModel
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public string AddressArea { get; set; }
        public string HospitalPhone { get; set; }
        public int CategoryID { get; set; }
        public string BusinessHours { get; set; }
        public string Emergency { get; set; }
        public string OutpatientProject { get; set; }
        public string Equipment { get; set; }
        public string WebAddress { get; set; }
        public string OnlineConsultation { get; set; }
        //刪除紀錄
        public string OnView { get; set; }
        public string Map { get; set; }
        public string CategoryName { get; set; }

        public string CategoryList { get; set; }
    }
}