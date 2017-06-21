using CaptainMao.Areas.Hospital.Models.ViewModel;
using CaptainMao.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Hospital.Controllers
{
    [AuthorizeMao(Roles = "Admin")]
    public class HospitalCRUDController : Controller
    {
        global::CaptainMao.Models.MaoEntities DB = new CaptainMao.Models.MaoEntities();
        //刪除


        // GET: Hospital/HospitalCRUD
        public ActionResult Aside()
        {
            return View();
        }

        //搜尋所有
        public ActionResult HospitalSearchCity()
        {
            var hospitalCitys = from a in DB.Cities select a;
            List<SelectListItem> HospitalText = new List<SelectListItem>();
            HospitalText.Add(new SelectListItem() { Text = "請選擇城市", Value = "" });
            foreach (var b in hospitalCitys)
            { HospitalText.Add(new SelectListItem() { Text = b.CityName, Value = b.CityID.ToString() }); }
            ViewBag.HospitalCity = HospitalText;

            var hospitalSearchPetRace = from a in DB.Categories select a;
            List<SelectListItem> HospitalTextRace = new List<SelectListItem>();
            HospitalTextRace.Add(new SelectListItem() { Text = "請選擇寵物", Value = "" });
            foreach (var b in hospitalSearchPetRace)
            { HospitalTextRace.Add(new SelectListItem() { Text = b.CategoryName, Value = b.CategoryID.ToString() }); }
            ViewBag.HospitalPetRace = HospitalTextRace;

            return View();
        }

        [HttpPost]
        public ActionResult _HospitalSearchCity(string CityID = "", string CategoryID = "", string HosName = "", string HospitalOnView = "")
        {

            var SaveAddressArea = string.IsNullOrWhiteSpace(CityID.ToString()) ? "" : CityID.ToString();
            var SaveCategoryID = string.IsNullOrWhiteSpace(CategoryID.ToString()) ? "" : CategoryID.ToString();
            var SaveHosName = string.IsNullOrWhiteSpace(HosName) ? "" : HosName;
            var SaveHospitalOnView = string.IsNullOrWhiteSpace(HospitalOnView) ? "" : HospitalOnView;

            var _hospitalSearchCity = from a in DB.Hospitals select a;
            if (SaveAddressArea != "")
            {
                _hospitalSearchCity = _hospitalSearchCity.Where(x => x.AddressArea.ToString() == SaveAddressArea);
            }
            if (SaveHosName != "")
            {
                _hospitalSearchCity = _hospitalSearchCity.Where(x => x.HospitalName.Contains(SaveHosName));
            }
            if (SaveHospitalOnView != "")
            {
                _hospitalSearchCity = _hospitalSearchCity.Where(x => x.OnView.ToString() == SaveHospitalOnView);
            }


            if (SaveCategoryID != "")
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
                if (SaveHospitalOnView != "")
                {
                    _hospitalSearchCity = _hospitalSearchCity.Where(x => x.OnView.ToString() == SaveHospitalOnView);
                }
            }

            ViewBag.Item = _hospitalSearchCity;
            return PartialView(_hospitalSearchCity.ToList());

        }

        public ActionResult HospitalSearchValue(int HospitalID = 2)
        {

            var hospitalSearchValue = from a in DB.Hospitals

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
            foreach (var aa in hospitalSearchValue)
            {
                Model = aa;
            }

            return View("~/Areas/Hospital/Views/HospitalCRUD/Index.cshtml", Model);
        }
        //起始頁 顯示所有資料
        public ActionResult Index()
        {
            var hospitalCitys = from a in DB.Cities select a;
            List<SelectListItem> HospitalText = new List<SelectListItem>();
            HospitalText.Add(new SelectListItem() { Text = "請選擇城市", Value = "" });
            foreach (var b in hospitalCitys)
            { HospitalText.Add(new SelectListItem() { Text = b.CityName, Value = b.CityID.ToString() }); }
            ViewBag.HospitalCity = HospitalText;

            foreach (var b in hospitalCitys)
            {
                HospitalText.Add(new SelectListItem()
                {
                    Text = b.CityName,
                    Value = b.CityID.ToString()
                });
            }
            ViewBag.HospitalCity = HospitalText;

            var hospitalSearchPetRace = from a in DB.Categories select a;
            List<SelectListItem> HospitalTextRace = new List<SelectListItem>();
            HospitalTextRace.Add(new SelectListItem() { Text = "請選擇寵物", Value = "" });
            foreach (var b in hospitalSearchPetRace)
            { HospitalTextRace.Add(new SelectListItem() { Text = b.CategoryName, Value = b.CategoryID.ToString() }); }
            ViewBag.HospitalPetRace = HospitalTextRace;

            List<SelectListItem> HospitalOnView = new List<SelectListItem>();
            HospitalOnView.Add(new SelectListItem() { Text = "請選擇狀態", Value = "" });
            HospitalOnView.Add(new SelectListItem() { Text = "開啟", Value = "1" });
            HospitalOnView.Add(new SelectListItem() { Text = "關閉", Value = "0" });
            ViewBag.HospitalOnView = HospitalOnView;

            return View();
        }


        //修改
        [HttpPost]
        public ActionResult UpDataGetHospital(int HospitalID = 2)
        {
            var hospitalSearchAll = from a in DB.Hospitals
                                    join b in DB.Cities on a.AddressArea equals b.CityID
                                    //join c in DB.HospitalCategoryDetails on a.HospitalID equals c.HospitalID
                                    //join d in DB.Categories on c.CategoryID equals d.CategoryID
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
                                        OnView = a.OnView,
                                        Map = a.Map,
                                        AddressArea = b.CityName
                                    };

            var getPat = from a in DB.Hospitals
                         join b in DB.Cities on a.AddressArea equals b.CityID
                         join c in DB.HospitalCategoryDetails on a.HospitalID equals c.HospitalID
                         join d in DB.Categories on c.CategoryID equals d.CategoryID
                         where a.HospitalID == HospitalID
                         select new HospitalModel
                         {
                             CategoryID = d.CategoryID
                         };

            int CategoryID1 = 0, CategoryID2 = 0, CategoryID3 = 0, CategoryID4 = 0, CategoryID5 = 0, CategoryID6 = 0;
            List<int> countList = new List<int>();
            foreach (var item in getPat)
            {
                countList.Add(item.CategoryID);
            }
            if (countList.IndexOf(1) > -1)
            {
                CategoryID1 = 1;
            }

            if (countList.IndexOf(2) > -1)
            {
                CategoryID2 = 1;
            }

            if (countList.IndexOf(3) > -1)
            {
                CategoryID3 = 1;
            }

            if (countList.IndexOf(4) > -1)
            {
                CategoryID4 = 1;
            }

            if (countList.IndexOf(5) > -1)
            {
                CategoryID5 = 1;
            }

            if (countList.IndexOf(6) > -1)
            {
                CategoryID6 = 1;
            }

            ViewBag.CategoryID1 = CategoryID1;
            ViewBag.CategoryID2 = CategoryID2;
            ViewBag.CategoryID3 = CategoryID3;
            ViewBag.CategoryID4 = CategoryID4;
            ViewBag.CategoryID5 = CategoryID5;
            ViewBag.CategoryID6 = CategoryID6;


            //repository
            return PartialView(hospitalSearchAll.ToList());
        }

        [HttpPost]
        public ActionResult UpDataHospital(CaptainMao.Areas.Hospital.Models.ViewModel.HospitalModel model)
        {
            //從前端取回選擇的寵物類別，並靠著|符號切開變成List
            string[] strArray = model.CategoryList.Split('|');

            var getAddressArea = from a in DB.Cities
                                 where a.CityName == model.AddressArea
                                 select a;

            //新增一筆要上傳的醫院資料(因為預設掛的是ViewModel，故需要自己繫結)
            CaptainMao.Models.Hospital NewHospital = new CaptainMao.Models.Hospital();
            NewHospital.HospitalID = model.HospitalID;
            NewHospital.HospitalName = model.HospitalName;
            NewHospital.HospitalAddress = model.HospitalAddress;
            NewHospital.AddressArea = getAddressArea.First().CityID;
            NewHospital.HospitalPhone = model.HospitalPhone;
            NewHospital.OnView = "1";
            NewHospital.BusinessHours = model.BusinessHours;
            NewHospital.Emergency = model.Emergency;
            NewHospital.OutpatientProject = model.OutpatientProject;
            NewHospital.Equipment = model.Equipment;
            NewHospital.WebAddress = model.WebAddress;
            NewHospital.OnlineConsultation = model.OnlineConsultation;
            NewHospital.Map = model.Map;

            //你們自己綁的，上傳還要CiytName參數，莫名其妙
            int toSaveAddressArea = getAddressArea.First().CityID;
            CaptainMao.Models.City FuckYouCityName = new CaptainMao.Models.City();
            var CheckThis = from Item in DB.Cities where Item.CityID == toSaveAddressArea select Item;

            foreach (var Item in CheckThis)
            {
                FuckYouCityName = Item;
            }

            NewHospital.City = FuckYouCityName;

            CaptainMao.Models.HospitalCategoryDetail deleteThis = new CaptainMao.Models.HospitalCategoryDetail();
            var DeleteHospitalCategoryDetail = from a in DB.HospitalCategoryDetails
                                               where a.HospitalID == model.HospitalID
                                               select a;

            foreach (var item in DeleteHospitalCategoryDetail)
            {
                deleteThis = item;
                DB.HospitalCategoryDetails.Remove(deleteThis);
            }



            //利用迴圈，上傳第二章關係表單
            for (int i = 0; i < strArray.Count() - 1; i++)
            {
                //新增一筆要上傳的寵物、醫院表單
                CaptainMao.Models.HospitalCategoryDetail NewHospitalCategoryDetail = new CaptainMao.Models.HospitalCategoryDetail();
                NewHospitalCategoryDetail.HospitalID = NewHospital.HospitalID;
                NewHospitalCategoryDetail.CategoryID = int.Parse(strArray[i]);

                //新增寵物、醫院表單資料
                DB.HospitalCategoryDetails.Add(NewHospitalCategoryDetail);
            }

            //都確認後新增醫院表單資料
            DB.Entry(NewHospital).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Hospital/HospitalCRUD");
        }
        //新增
        [HttpGet]
        public ActionResult CreatHospital()
        {
            var hospitalCitys = from a in DB.Cities select a;
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
        public ActionResult CreatHospital(CaptainMao.Areas.Hospital.Models.ViewModel.HospitalModel model)
        {
            //從前端取回選擇的寵物類別，並靠著|符號切開變成List
            string[] strArray = model.CategoryList.Split('|');

            //新增一筆要上傳的醫院資料(因為預設掛的是ViewModel，故需要自己繫結)
            CaptainMao.Models.Hospital NewHospital = new CaptainMao.Models.Hospital();
            NewHospital.HospitalName = model.HospitalName;
            NewHospital.HospitalAddress = model.HospitalAddress;
            NewHospital.AddressArea = int.Parse(model.AddressArea);
            NewHospital.HospitalPhone = model.HospitalPhone;
            NewHospital.OnView = "1";
            NewHospital.BusinessHours = model.BusinessHours;
            NewHospital.Emergency = model.Emergency;
            NewHospital.OutpatientProject = model.OutpatientProject;
            NewHospital.Equipment = model.Equipment;
            NewHospital.WebAddress = model.WebAddress;
            NewHospital.OnlineConsultation = model.OnlineConsultation;
            NewHospital.OnView = model.OnView;
            NewHospital.Map = model.Map;

            //你們自己綁的，上傳還要CiytName參數，莫名其妙
            int toSaveAddressArea = int.Parse(model.AddressArea);
            CaptainMao.Models.City FuckYouCityName = new CaptainMao.Models.City();
            var CheckThis = from Item in DB.Cities where Item.CityID == toSaveAddressArea select Item;

            foreach (var Item in CheckThis)
            {
                FuckYouCityName = Item;
            }

            NewHospital.City = FuckYouCityName;

            //利用迴圈，上傳第二章關係表單
            for (int i = 0; i < strArray.Count() - 1; i++)
            {
                //新增一筆要上傳的寵物、醫院表單
                CaptainMao.Models.HospitalCategoryDetail NewHospitalCategoryDetail = new CaptainMao.Models.HospitalCategoryDetail();
                NewHospitalCategoryDetail.HospitalID = NewHospital.HospitalID;
                NewHospitalCategoryDetail.CategoryID = int.Parse(strArray[i]);

                //新增寵物、醫院表單資料
                DB.HospitalCategoryDetails.Add(NewHospitalCategoryDetail);
            }

            //都確認後新增醫院表單資料
            DB.Hospitals.Add(NewHospital);

            try
            {
                DB.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Hospital/HospitalCRUD");
        }
        //刪除
        public ActionResult RemoveHospital(int id = 2)
        {
            var removeHospital = (from a in DB.Hospitals
                                  where a.HospitalID == id
                                  select a).FirstOrDefault();
            if (removeHospital.Equals(null))
            { }
            removeHospital.OnView = "0";
            DB.SaveChanges();

            return RedirectToAction("Index", "HospitalCRUD");

        }
        //顯示
        public ActionResult reRemoveHospital(int id = 2)
        {
            var removeHospital = (from a in DB.Hospitals
                                  where a.HospitalID == id
                                  select a).FirstOrDefault();
            if (removeHospital.Equals(null))
            { }
            removeHospital.OnView = "1";
            DB.SaveChanges();

            return RedirectToAction("Index", "HospitalCRUD");

        }
    }
}