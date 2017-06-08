using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Models;
using CaptainMao.Areas.Adoption.Models;
using CaptainMao.Areas.Adoption.ViewModel;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

namespace CaptainMao.Areas.Adoption.Controllers
{
    public class AdoptionController : Controller
    {
        CaptainMao.Models.MaoEntities db = new MaoEntities();
        IRepository<CaptainMao.Models.Adoption> dbAdoption = new Repository<CaptainMao.Models.Adoption>();
        IRepository<AdpWish> dbAdpWish = new Repository<AdpWish>();

        [ChildActionOnly]
        public ActionResult Aside()
        {
            return View();
        }

        // GET: Adoption/Adoption
        public ActionResult Index(int? page, int? categoryid, int? cityid,string search)
        {
            
            var adoptions = db.Adoptions.Select(a => a);

            if (search != "" && search != null)
            {
                adoptions = adoptions.Where(a => a.Age.Contains(search) || a.Build.Contains(search) || a.Sex.Contains(search));
            }
            if (categoryid != null)
            {
                adoptions = adoptions.Where(a => a.CategoryID == categoryid);
                var cate = db.Categories.Where(c => c.CategoryID == categoryid).Select(c => c.CategoryName).ToList();
                ViewBag.category = cate[0];
            }
            if (cityid != null)
            {
                adoptions = adoptions.Where(a => a.CityID == cityid);
                var city = db.Citys.Where(c => c.CityID == cityid).Select(c => c.CityName).ToList();
                ViewBag.city = city[0];
            }
            return View(adoptions.OrderByDescending(a => a.PostDate).ToList().ToPagedList(page ?? 1, 6));
        }

        // GET: Adoption/Adoption/Details/5
        public ActionResult Details(int id)
        {
            AdoptionViewModel vm = new AdoptionViewModel();
            vm.adoption = db.Adoptions.Find(id);

            vm.category = db.Categories.Find(vm.adoption.CategoryID);
            vm.city = db.Citys.Find(vm.adoption.CityID);
            return View(vm);
        }

        public ActionResult GetImage(int id)
        {
            var adoption = db.Adoptions.Find(id);
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
        public ActionResult CreateAdoption(CaptainMao.Models.Adoption pet, HttpPostedFileBase PetImage)
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Citys.ToList();

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

            if (ModelState.IsValid)
            {
                if (pet.Name == null)
                {
                    pet.Name = "~未命名~";
                }
                if (pet.Sex == null)
                {
                    pet.Sex = "~不明~";
                }
                pet.RegistrationUserID = "QWE";
                pet.PostDate = DateTime.Now;
                dbAdoption.Create(pet);
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult AdoptionManage()
        {
            Adoption_WishViewModel vm = new Adoption_WishViewModel();
            string UserID = User.Identity.GetUserId();
            vm.adoptions = db.Adoptions.Where(a => a.RegistrationUserID == UserID);
            vm.wishs = db.AdpWishes.Where(a => a.UserID == UserID);
            bool flg1 = false;
            bool flg2 = false;
            if (vm.adoptions.Count() > 0)
            {
                flg1 = true;
            }
            ViewBag.flag1 = flg1;

            if (vm.wishs.Count() > 0)
            {
                flg2 = true;
            }
            ViewBag.flag2 = flg2;
            return View(vm);
        }

        // GET: Adoption/Adoption/Edit/5
        public ActionResult Edit(int id)
        {
            var adoption = db.Adoptions.Find(id);
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Citys.ToList();

            return View(adoption);
        }

        // POST: Adoption/Adoption/Edit/5
        [HttpPost]
        public ActionResult Edit(CaptainMao.Models.Adoption adoption, HttpPostedFileBase PetImage)
        {
            if (PetImage != null)
            {
                var ImgSize = PetImage.ContentLength;
                byte[] ImgByte = new byte[ImgSize];
                PetImage.InputStream.Read(ImgByte, 0, ImgSize);

                adoption.PetImage = PetImage.FileName;
                adoption.BytesImage = ImgByte;
            }

            if (adoption.Name == null)
            {
                adoption.Name = "~未命名~";
            }
            if (adoption.Sex == null)
            {
                adoption.Sex = "~未知~";
            }

            if (ModelState.IsValid)
            {
                adoption.PostDate = DateTime.Now;
                dbAdoption.Update(adoption);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Adoption/Adoption/Delete/5
        public ActionResult Delete(int id)
        {
            var adoption = db.Adoptions.Find(id);
            db.Adoptions.Remove(adoption);
            db.SaveChanges();
            //dbContext.Delete(adoption);
            return RedirectToAction("AdoptionManage");
        }

        public ActionResult AdoptionWish(int? page, int? categoryid, int? cityid, string search)
        {
            var wishs = db.AdpWishes.Select(a => a);

            if (search != "" && search != null)
            {
                wishs = wishs.Where(a => a.Age.Contains(search) || a.Build.Contains(search) || a.Sex.Contains(search));
            }
            if (categoryid != null)
            {
                wishs = wishs.Where(a => a.CategoryID == categoryid);
                var cate = db.Categories.Where(c => c.CategoryID == categoryid).Select(c => c.CategoryName).ToList();
                ViewBag.category = cate[0];
            }
            if (cityid != null)
            {
                wishs = wishs.Where(a => a.CityID == cityid);
                var city = db.Citys.Where(c => c.CityID == cityid).Select(c => c.CityName).ToList();
                ViewBag.city = city[0];
            }
            return View(wishs.OrderByDescending(a => a.PostDate).ToList().ToPagedList(page ?? 1,6));
        }

        public ActionResult CreateAdpWish()
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Citys.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdpWish(AdpWish wish)
        {
            if (wish != null)
            {
                wish.UserID = "QWE";
                wish.PostDate = DateTime.Now;
                dbAdpWish.Create(wish);
                return RedirectToAction("AdoptionWish");
            }

            return View();
        }

        public ActionResult WishJoin(int id)
        {
            var wish = db.AdpWishes.Find(id);
            var result = db.Adoptions.Where(a => a.CategoryID == wish.CategoryID 
                                                                          && a.CityID == wish.CityID 
                                                                          && (a.Sex == wish.Sex || a.Build == wish.Build || a.Age == wish.Age || a.Hair == wish.Hair));
            ViewBag.wishID = id;
            return View(result);
        }

        public ActionResult Email(int id)
        {
            System.Net.Mail.SmtpClient MySmtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

            //設定你的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("captainmao114@gmail.com", "gogoP@ssw0rd");

            //Gmial 的 smtp 必需要使用 SSL
            MySmtp.EnableSsl = true;

            var adoption = db.Adoptions.Find(id);
            string Email = adoption.AspNetUser.Email;
            //發送Email
            MySmtp.Send("captainmao114@gmail.com", Email, "毛孩隊長",
                        "親愛的用戶您好，有其他用戶領養您的寵物 "+ "http://localhost:52326/Adoption/Adoption/Details/" + id +"，請您盡速回覆，謝謝。");
            MySmtp.Dispose();
            return RedirectToAction("Index");
        }
    }
}
