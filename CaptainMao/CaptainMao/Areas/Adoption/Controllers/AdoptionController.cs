﻿using System;
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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

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
                var city = db.Cities.Where(c => c.CityID == cityid).Select(c => c.CityName).ToList();
                ViewBag.city = city[0];
            }
            return View(adoptions.OrderByDescending(a => a.PostDate).ToList().ToPagedList(page ?? 1, 6));
        }

        // GET: Adoption/Adoption/Details/5
        public ActionResult Details(int id)
        {
            AdoptionViewModel vm = new AdoptionViewModel();
            vm.adoption = db.Adoptions.Find(id);
            vm.NickName = vm.adoption.AspNetUser.NickName;
            vm.PhoneNumber = vm.adoption.AspNetUser.PhoneNumber;
            vm.Email = vm.adoption.AspNetUser.Email;
            vm.category = db.Categories.Find(vm.adoption.CategoryID);
            vm.city = db.Cities.Find(vm.adoption.CityID);
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
            var UserID = User.Identity.GetUserId();
            if (UserID == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "" });
            }
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Cities.ToList();
            return View();
        }

        // POST: Adoption/Adoption/Create
        [HttpPost]
        public ActionResult CreateAdoption(CaptainMao.Models.Adoption pet, HttpPostedFileBase PetImage)
        {
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Cities.ToList();

            pet.RegistrationUserID = User.Identity.GetUserId();
            pet.PostDate = DateTime.Now;

            if (PetImage != null)
            {
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
            ViewBag.City = db.Cities.ToList();

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

                return RedirectToAction("AdoptionManage");
            }

            return View();
        }

        // GET: Adoption/Adoption/Delete/5
        public ActionResult Delete(int id)
        {
            var adoption = db.Adoptions.Find(id);
            db.Adoptions.Remove(adoption);
            db.SaveChanges();
            //dbAdoption.Delete(adoption);
            TempData["delete"] = true;
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
                var city = db.Cities.Where(c => c.CityID == cityid).Select(c => c.CityName).ToList();
                ViewBag.city = city[0];
            }
            return View(wishs.OrderByDescending(a => a.PostDate).ToList().ToPagedList(page ?? 1,6));
        }

        public ActionResult CreateAdpWish()
        {
            var UserID = User.Identity.GetUserId();
            if (UserID == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "" });
            }
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Cities.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdpWish(AdpWish wish)
        {
            if (wish != null)
            {
                wish.UserID = User.Identity.GetUserId();
                wish.PostDate = DateTime.Now;
                dbAdpWish.Create(wish);
                return RedirectToAction("AdoptionWish");
            }

            return View();
        }

        public ActionResult EditWish(int id)
        {
            var adoption = db.AdpWishes.Find(id);
            ViewBag.Category = db.Categories.ToList();
            ViewBag.City = db.Cities.ToList();

            return View(adoption);
        }

        // POST: Adoption/Adoption/Edit/5
        [HttpPost]
        public ActionResult EditWish(CaptainMao.Models.AdpWish adoption)
        {                 
            if (ModelState.IsValid)
            {
                adoption.PostDate = DateTime.Now;
                dbAdpWish.Update(adoption);

                return RedirectToAction("AdoptionManage");
            }

            return View();
        }

        public ActionResult DeleteWish(int id)
        {
            var adoption = db.AdpWishes.Find(id);
            db.AdpWishes.Remove(adoption);
            db.SaveChanges();
            TempData["delete"] = true;
            return RedirectToAction("AdoptionManage");
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

        //NoView function
        public async Task<ActionResult> Email(int id)
        {
            var UserID = User.Identity.GetUserId();
            if (UserID == null)
            {
                return RedirectToAction("Login", "Account", new { Area = "" });
            }
            var user = db.AspNetUsers.Where(u => u.Id == UserID).First();
            var emailTo = db.Adoptions.Find(id).AspNetUser;
                                

            string callbackUrl = "http://localhost:52326/Adoption/Adoption/Details/" + id;
            string emailContent = "<h3>" + emailTo.LastName + " " + emailTo.FirstName + "您好，</h3>" +
                                                      "<p>有其他的用戶對您的小寵物有興趣，請您盡快與他聯絡</p>" +
                                                      "<p>聯絡人:" + user.LastName + " " + user.FirstName + "</p>"+
                                                      "<p>聯絡電話:" + user.PhoneNumber + "</p>" +
                                                      "<p>請按一下此連結確認小寵物的資訊 <a href='" + callbackUrl +
                                                      "'>確認小寵物</a></p>";
            var service = new EmailService();
            IdentityMessage message = new IdentityMessage { Body = emailContent, Destination = emailTo.Email, Subject = "【毛孩隊長寵物生活網】領養通知信" };
            await service.SendAsync(message);

            //await UserManager.SendEmailAsync(emailTo.Id, "【毛孩隊長寵物生活網】用戶註冊確認信", emailContent);
            TempData["email"] = true;
            return RedirectToAction("Index");
        }

        public ActionResult GetUserImage(string id)
        {
            var photo = db.AspNetUsers.Where(u => u.Id == id).Select(u => u.Photo).First();
            byte[] img = photo;
            return File(img, "image/jpeg");
        }

    }
}
