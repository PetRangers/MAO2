using CaptainMao.Areas.Hospital.Models.ViewModel;
using Microsoft.AspNet.Identity;
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

        public ActionResult Aside()
        {
            return View();
        }
        public ActionResult HospitalSearchCity()
        {
            var hospitalCitys = from a in DB.Cities select a;
            List<SelectListItem> HospitalText = new List<SelectListItem>();
            HospitalText.Add(new SelectListItem() { Text ="請選擇城市", Value = "" });
            foreach (var b in hospitalCitys)
            { HospitalText.Add(new SelectListItem() { Text = b.CityName, Value = b.CityID.ToString() }); }
            ViewBag.HospitalCity = HospitalText;

            var hospitalSearchPetRace = from a in DB.Categories select a;
            List<SelectListItem> HospitalTextRace = new List<SelectListItem>();
            HospitalTextRace.Add(new SelectListItem() { Text ="請選擇寵物", Value ="" });
            foreach (var b in hospitalSearchPetRace)
            { HospitalTextRace.Add(new SelectListItem() { Text = b.CategoryName, Value = b.CategoryID.ToString() }); }
            ViewBag.HospitalPetRace = HospitalTextRace;

            return View();
        }

        [HttpPost]
        public ActionResult _HospitalSearchCity(string CityID ="", string CategoryID = "",string HosName = "")
        {
            var SaveAddressArea = string.IsNullOrWhiteSpace(CityID.ToString()) ? "" : CityID.ToString();
            var SaveCategoryID = string.IsNullOrWhiteSpace(CategoryID.ToString()) ? "" : CategoryID.ToString();
            var SaveHosName = string.IsNullOrWhiteSpace(HosName) ? "" : HosName;

            var _hospitalSearchCity = from a in DB.Hospitals select a;
            if (SaveAddressArea != "")
            {
                _hospitalSearchCity = _hospitalSearchCity.Where(x => x.AddressArea.ToString() == SaveAddressArea);
            }
            if (SaveHosName != "")
            {
                _hospitalSearchCity = _hospitalSearchCity.Where(x => x.HospitalName.Contains(SaveHosName));
            }


            if (SaveHosName != "")
            {
                _hospitalSearchCity = from a in DB.Hospitals
                                      join b in DB.HospitalCategoryDetails on a.HospitalID equals b.HospitalID
                                      where b.CategoryID.ToString() == SaveCategoryID
                                      select a;

                if (SaveAddressArea != "")
                {
                    _hospitalSearchCity = _hospitalSearchCity.Where(x => x.AddressArea.ToString() == SaveAddressArea);
                }
                if (SaveHosName != "")
                {
                    _hospitalSearchCity = _hospitalSearchCity.Where(x => x.HospitalName.Contains(SaveHosName));
                }
            }
            
            //var _hospitalSearchCity = from a in DB.Hospitals
            //join b in DB.HospitalCategoryDetails on a.HospitalID equals b.HospitalID                                     
            //where a.AddressArea.ToString() == SaveAddressArea && b.CategoryID.ToString() == SaveCategoryID && a.HospitalName.Contains(SaveHosName)
            //select a;

            //LINQ Expression 語法     

            ViewBag.Item = _hospitalSearchCity;


            return PartialView( _hospitalSearchCity.ToList());
        }

        public ActionResult HospitalSearchValue(int HospitalID = 2)
        {

            var hospitalSearchValue = from a in DB.Hospitals
                                          //join b in DB.Cities on a.AddressArea equals b.CityID
                                          //join c in DB.Categories on a.CategoryID equals c.CategoryID
                                      join b in DB.HospitalCategoryDetails on a.HospitalID equals b.HospitalID
                                      join c in DB.Categories on b.CategoryID equals c.CategoryID
                                      where a.HospitalID == HospitalID
                                      select new HospitalModel
                                      {
                                          HospitalID = a.HospitalID,
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
            //預存給評分用的資料
            ViewBag.HospitalName = Model.HospitalName;
            ViewBag.HospitalID = HospitalID;

            var getStarSUM = from a in DB.Scorces
                             group a by new { a.Scorce1 } into g
                             select new { g.Key, Count = g.Count() };

            string S1 = "";
            string S2 = "";
            string S3 = "";
            string S4 = "";
            string S5 = "";


            foreach (var item in getStarSUM)
            {
                if (item.Key.Scorce1 == 1)
                {
                    S1 = item.Count.ToString();
                }
                if (item.Key.Scorce1 == 2)
                {
                    S2 = item.Count.ToString();
                }
                if (item.Key.Scorce1 == 3)
                {
                   S3 = item.Count.ToString();
                }
                if (item.Key.Scorce1 == 4)
                {
                    S4 = item.Count.ToString();
                }
                if (item.Key.Scorce1 == 5)
                {
                    S5 = item.Count.ToString();
                }

            }
            ViewBag.S1 = S1;
            ViewBag.S2 = S2;
            ViewBag.S3 = S3;
            ViewBag.S4 = S4;
            ViewBag.S5 = S5;

            var getId = hospitalSearchValue.First().HospitalID;

            var GetAddress = from a in DB.Hospitals
                             where a.HospitalID == getId
                             select a;

            ViewBag.MapL = "台北市大安區復興南路一段390號";
            ViewBag.EndMap = GetAddress.First().HospitalAddress;

            return View(Model);
        }
        public ActionResult ShowThisNote(int HospitalID = 2)
        {
            var getThisAllItem = from item in DB.Scorces
                                 where item.HospitalID == HospitalID
                                 select item;

            return PartialView(getThisAllItem.ToList());
        }


        //地圖
        public ActionResult Map(int HospitalID = 2)
        {            
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
            //var ListToNote = from a in DB.Scorces
            //                 where a.UserID == model.UserID
            //                 select a;
            //if (ListToNote.Count() > 0)
            //{
            //    if (model.UserID == ListToNote.First().UserID)
            //    {
            //        return Content("<script>alert('您已經給予評價過了唷！');</script>");
            //    }
            //}
            var GetUser = User.Identity.GetUserId();
            try
            {
                CaptainMao.Models.AspNetUser AspNetUser = new CaptainMao.Models.AspNetUser();
                var GetAspNetUser = from a in DB.AspNetUsers where a.Id == GetUser select a;
                foreach (var User in GetAspNetUser)
                {
                    AspNetUser = User;
                }

                CaptainMao.Models.Hospital Hospital = new CaptainMao.Models.Hospital();
                var GetHospital = from a in DB.Hospitals where a.HospitalID == model.HospitalID select a;
                foreach (var item in GetHospital)
                {
                    Hospital = item;
                }

                var UpdateItem = new CaptainMao.Models.Scorce
                {
                    UserID =AspNetUser.NickName,
                    HospitalID = model.HospitalID,
                    Scorce1 = model.Score,
                    Date = DateTime.Now.ToString(),
                    NoteValue = model.NoteValue,
                    Hospital = Hospital,
                    AspNetUser = AspNetUser
                };
                DB.Scorces.Add(UpdateItem);
                DB.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("HospitalSearchValue", new { HospitalID = model.HospitalID });
        }

    }
}