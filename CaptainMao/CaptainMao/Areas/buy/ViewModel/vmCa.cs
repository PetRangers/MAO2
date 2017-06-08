﻿using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.buy.ViewModel
{
    public class vmType_sType
    {
        public int sType_ID { get; set; }
        public string sType_Name { get; set; }

        //public int Type_ID { get; set; }
    }

    public class vmCa_Type
    {
        public int Type_ID { get; set; }
        public string Type_Name { get; set; }
        public List<vmType_sType> sType{ get; set; }
    }

    public class vmCaID_stypeID
    {
        public int? CategoryID { get; set; }
        public int? Type_ID { get; set; }
        public int? sType_ID { get; set; }
    }
    public class vmCa_Mer
    {
        public IEnumerable<Category> _Category { get; set; }


        public Merchandise _Merchandise { get; set; }


        public IEnumerable<CaptainMao.Models.sType> _sType { get; set; }



        [Required(ErrorMessage="至少選一個分類")]
        public string[] sType_ID { get; set; }
    }





}