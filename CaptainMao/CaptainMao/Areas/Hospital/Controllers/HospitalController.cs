using CaptainMao.Areas.Hospital.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Hospital.Controllers
{
    public class HospitalController : Controller
    {
        global::CaptainMao.Models.MaoEntities DB = new CaptainMao.Models.MaoEntities();
        // GET: Hospital/Hospital
        public ActionResult HospitalSearchCity()
        {
            var hospitalCitys = from a in DB.Citys select a;
            List<SelectListItem> HospitalText = new List<SelectListItem>();
            foreach (var b in hospitalCitys)
            { HospitalText.Add(new SelectListItem() { Text = b.CityName, Value = b.CityID.ToString() }); }
            ViewBag.HospitalCity = HospitalText;

            var hospitalSearchPetRace = from a in DB.Categories select a;
            List<SelectListItem> HospitalTextRace = new List<SelectListItem>();
            foreach (var b in hospitalSearchPetRace)
            { HospitalTextRace.Add(new SelectListItem() { Text = b.CategoryName, Value = b.CategoryID.ToString() }); }
            ViewBag.HospitalPetRace = HospitalTextRace;

            return View();
        }

        [HttpPost]
        public ActionResult _HospitalSearchCity(int CityID = 1, int CategoryID = 1)
        {
            //string chack = string.IsNullOrEmpty(CityID.ToString()) ? "1" : CityID.ToString();

            var _hospitalSearchCity = from a in DB.Hospitals
                                      join b in DB.HospitalCategoryDetails on a.HospitalID equals b.HospitalID
                                      where a.AddressArea == CityID && b.CategoryID == CategoryID
                                      select a;

            ViewBag.Item = _hospitalSearchCity;


            return PartialView( _hospitalSearchCity.ToList());
        }

        public ActionResult HospitalSearchValue(int HospitalID = 1)
        {

            var hospitalSearchValue = from a in DB.Hospitals
                                          //join b in DB.Citys on a.AddressArea equals b.CityID
                                          //join c in DB.Categories on a.CategoryID equals c.CategoryID
                                      join b in DB.HospitalCategoryDetails on a.HospitalID equals b.HospitalID
                                      join c in DB.Categories on b.CategoryID equals c.CategoryID
                                      where a.HospitalID == HospitalID
                                      select new HospitalModel
                                      {
                                          HospitalName = a.HospitalName,
                                          HospitalAddress = a.HospitalAddress,
                                          HospitalPhone = a.HospitalPhone,
                                          BusinessHours = a.BusinessHours,
                                          Emergency = a.Emergency,
                                          OutpatientProject = a.OutpatientProject,
                                          Equipment = a.Equipment,
                                          WebAddress = a.WebAddress,
                                          OnlineConsultation = a.OnlineConsultation,
                                          Map = a.Map,
                                          AddressArea = a.City.CityName,
                                          CategoryName = c.CategoryName
                                      };
            string SetName = null;
            foreach (var item in hospitalSearchValue)
            {
                SetName += item.CategoryName + " ";
            }

            ViewBag.SetName = SetName;

            HospitalModel Model = new HospitalModel();
            foreach(var aa in hospitalSearchValue)
            {
                Model = aa;
            }


            var getStarSUM = from a in DB.Hospitals
                             group a by new { a.AddressArea } into g
                             select new { g.Key, Count = g.Count() };

            string zS = "";
            string xS = "";
            string cS = "";
            foreach (var item in getStarSUM)
            {
                if (item.Key.AddressArea == 1)
                {
                    zS = item.Count.ToString();
                }
                if (item.Key.AddressArea == 2)
                {
                    xS = item.Count.ToString();
                }
                if (item.Key.AddressArea == 6)
                {
                    cS = item.Count.ToString();
                }

            }
            ViewBag.zS = zS;
            ViewBag.xS = xS;
            ViewBag.cS = cS;

            return View("~/Areas/Hospital/Views/Hospital/HospitalSearchValue.cshtml", Model);
        }

        //地圖
        public ActionResult Map()
        {
            ViewBag.MapLF = "{ lat: 25.0853115, lng: 121.59111029999997 }";
            ViewBag.MapL = 25.0853115;
            ViewBag.MapF = 121.59111029999997;
            return PartialView("~/Areas/Hospital/Views/Hospital/Map.cshtml");
        }
        public ActionResult ListToHospital()
        {
            var GetHospitalList = from a in DB.Hospitals
                                  select a;

            return View(GetHospitalList.ToList());
        }

        //[HttpGet]
        //public ActionResult ListToNote(int HospitalID = 1)
        //{
        //    var ListToNote = from a in DB.Scorce
        //                     where a.HospitalID == HospitalID
        //                     select a;

        //    var GetHospitalName = from b in DB.Hospital
        //                          where b.HospitalID == HospitalID
        //                          select b;

        //}
        //評分
        [HttpPost]
        public ActionResult ListToNote(HospitalNoteModel model)
        {
            var ListToNote = from a in DB.Scorces
                             where a.UserID == model.UserID
                             select a;
            if (ListToNote.Count() > 0)
            {
                if (model.UserID == ListToNote.First().UserID)
                {
                    return Content("<script>alert('您已經給予評價過了唷！');</script>");
                }
            }
            var UpdateItem = new CaptainMao.Models.Scorce
            {
                UserID = model.UserID,
                HospitalID = model.HospitalID,
                Scorce1 = model.Score,
                Date = model.Date,
                NoteValue = model.NoteValue
            };
            DB.Scorces.Add(UpdateItem);
            DB.SaveChanges();
            return RedirectToAction("ListToHospital");
        }

    }
}