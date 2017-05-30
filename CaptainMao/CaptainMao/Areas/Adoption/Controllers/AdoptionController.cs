using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Areas.Adoption.Models;
using CaptainMao.Areas.Adoption.ViewModel;

namespace CaptainMao.Areas.Adoption.Controllers
{
    public class AdoptionController : Controller
    {
        MaoEntities db = new MaoEntities();
        IRepository<Models.Adoption> dbContext = new Repository<Models.Adoption>();
        
        [ChildActionOnly]
        public ActionResult Aside()
        {
            return View();
        }

        // GET: Adoption/Adoption
        public ActionResult Index()
        {
            return View(db.Adoption.ToList());
        }

        // GET: Adoption/Adoption/Details/5
        public ActionResult Details(int id)
        {
            AdoptionViewModel vm = new AdoptionViewModel();            
            vm.adoption = db.Adoption.Find(id);

            vm.category = db.Categories.Find(vm.adoption.CategoryID);
            vm.city = db.Citys.Find(vm.adoption.CityID);
            return View(vm);
        }

        public ActionResult GetImage(int id)
        {
            var adoption = db.Adoption.Find(id);
            byte[] img = adoption.BytesImage;
            return File(img, "image/jpeg");
        }

        // GET: Adoption/Adoption/Create
        public ActionResult CreateAdoption()
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Citys.ToList();
            return View();
        }

        // POST: Adoption/Adoption/Create
        [HttpPost]
        public ActionResult CreateAdoption(Adoption.Models.Adoption pet, HttpPostedFileBase PetImage)
        {
            if (PetImage != null)
            {
                string strPath = Request.PhysicalApplicationPath + @"Images\" + PetImage.FileName;
                PetImage.SaveAs(strPath);

                var ImgSize = PetImage.ContentLength;
                byte[] ImgByte = new byte[ImgSize];
                PetImage.InputStream.Read(ImgByte, 0, ImgSize);

                pet.PetImage = PetImage.FileName;
                pet.BytesImage = ImgByte;
            }

            if (pet != null)
            {
                pet.PostDate = DateTime.Now;
                dbContext.Create(pet);
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult AdoptionManage()
        {
            int UserID = 4;
            var adoption = db.Adoption.Where(a => a.RegistrationUserID == UserID);
            return View(adoption.ToList());
        }

        // GET: Adoption/Adoption/Edit/5
        public ActionResult Edit(int id)
        {
            var adoption = db.Adoption.Find(id);
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Citys.ToList();

            return View(adoption);
        }

        // POST: Adoption/Adoption/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Adoption adoption, HttpPostedFileBase PetImage)
        {
            if (PetImage != null)
            {
                var ImgSize = PetImage.ContentLength;
                byte[] ImgByte = new byte[ImgSize];
                PetImage.InputStream.Read(ImgByte, 0, ImgSize);

                adoption.PetImage = PetImage.FileName;
                adoption.BytesImage = ImgByte;
            }
            adoption.PostDate = DateTime.Now;
            dbContext.Update(adoption);

            return RedirectToAction("Index");
            
        }

        // GET: Adoption/Adoption/Delete/5
        public ActionResult Delete(int id)
        {
            var adoption = db.Adoption.Find(id);
            db.Adoption.Remove(adoption);
            db.SaveChanges();
            //dbContext.Delete(adoption);
            return RedirectToAction("Index");
        }


    }
}
