using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Hospital.Models.ViewModel
{
    public class HospitalNoteModel
    {
        public string UserID { get; set; }
        public int HospitalID { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        public string NoteValue { get; set; }
    }
}