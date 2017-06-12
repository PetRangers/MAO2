using CaptainMao.Areas.Hospital.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Hospital.Controllers
{
    public class HospitalCRUDController : Controller
    {
        global::CaptainMao.Models.MaoEntities DB = new CaptainMao.Models.MaoEntities ();

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
        public ActionResult Index()
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

            var hospitalSearchAll = from a in DB.Hospitals
                                    join b in DB.Cities on a.AddressArea equals b.CityID
                                    join c in DB.Categories on a.CategoryID equals c.CategoryID
                                    select new HospitalModel
                                    {
                                     HospitalID=a.HospitalID,
                                        HospitalName = a.HospitalName,
                                        HospitalAddress = a.HospitalAddress,
                                        AddressArea = b.CityName,
                                        HospitalPhone = a.HospitalPhone,
                                        CategoryName = c.CategoryName
                                    };

            return View(hospitalSearchAll.ToList());
        }


        //修改
        [HttpGet]
        public ActionResult UpDataHospital(int id = 2)
        {
            var hospitalSearchAll = (from a in DB.Hospitals
                                     join b in DB.Cities on a.AddressArea equals b.CityID
                                     join c in DB.Categories on a.CategoryID equals c.CategoryID
                                     where a.HospitalID == id
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
                                         AddressArea = b.CityName,
                                         CategoryName = c.CategoryName
                                     }).First();
            //repository
            return View(hospitalSearchAll);
        }
        [HttpPost]
        public ActionResult UpDataHospital(HospitalModel Model)
        {
            DB.Entry(Model).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //新增
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

            if (Request.Form.Count > 0)
            {
                CaptainMao.Models.Hospital CreatNewHospital = new CaptainMao.Models.Hospital();
                CreatNewHospital.HospitalName = Request.Form["HospitalName"];
                CreatNewHospital.HospitalAddress = Request.Form["HospitalAddress"];
                CreatNewHospital.AddressArea = Int32.Parse(Request.Form["AddressArea"]);
                CreatNewHospital.HospitalPhone = Request.Form["HospitalPhone"];
                CreatNewHospital.CategoryID = Int32.Parse(Request.Form["CategoryID"]);
                CreatNewHospital.BusinessHours = Request.Form["BusinessHours"];
                CreatNewHospital.Emergency = Request.Form["Emergency"];
                CreatNewHospital.WebAddress = Request.Form["WebAddress"];
                CreatNewHospital.OnlineConsultation = Request.Form["OnlineConsultation"];

                DB.Hospitals.Add(CreatNewHospital);
                DB.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        //刪除
        public ActionResult RemoveHospital(int id = 0)
        {
            var removeHospital = (from a in DB.Hospitals
                                  where a.HospitalID == id
                                  select a).FirstOrDefault();
            if (removeHospital.Equals(null))
            { }
            removeHospital.OnView = "0";
            DB.SaveChanges();

            return View("Index");

        }
    }
}