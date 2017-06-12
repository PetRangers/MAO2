using CaptainMao.Areas.Admin.Models;
using CaptainMao.Filters;
using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    //[AuthorizeMao()]
    public class NormalUserController : Controller
    {
        private MaoEntities db = new MaoEntities();
            
        // GET: Admin/NormalUser
        public ActionResult Index()
        {
            //找出所有一般使用者
            var aspUsers = db.AspNetRoles.Where(u=>u.Name=="Normal").First().AspNetUsers.ToList();

            //找出一般使用者的另一種寫法。有趣的是，從使用者出發的linq寫法反而比較迂迴。
            //AspNetRole role = db.AspNetRoles.Where(x=>x.Name=="Normal").First();
            //var aspUsers = db.AspNetUsers.Where(u=>u.AspNetRoles.Contains(role)).ToList();

            List<NormalUserViewModel> normalUsers = new List<NormalUserViewModel>();
            foreach (var u in aspUsers)
            {
                NormalUserViewModel user = new NormalUserViewModel
                {
                    Id=u.Id,
                    UserName=u.UserName,
                    FirstName =u.FirstName,
                    LastName =u.LastName,
                    NickName =u.NickName,
                    PhoneNumber =u.PhoneNumber,
                    DateRegistered =u.DateRegistered,
                    Photo = "data:image /; base64," + Convert.ToBase64String(u.Photo)
                };
                normalUsers.Add(user);
            }
            return View(normalUsers);
        }

        // 單一使用者資料明細
        // GET: Admin/NormalUser/Details/id
        public ActionResult Details(string id)
        {
            var aspUser = db.AspNetUsers.Where(u=>u.Id == id).First();
            if (aspUser == null)
            {
                return HttpNotFound();
            }
            NormalUserDetailViewModel user = new NormalUserDetailViewModel
            {
                AccessFailedCount=aspUser.AccessFailedCount,
                DateRegistered =aspUser.DateRegistered,
                Id =aspUser.Id,
                EmailConfirmed =aspUser.EmailConfirmed,
                Experience =aspUser.Experience,
                FirstName =aspUser.FirstName,
                LastName =aspUser.LastName,
                LockoutEnabled =aspUser.LockoutEnabled,
                LockoutEndDateUtc =aspUser.LockoutEndDateUtc,
                NickName =aspUser.NickName,
                PhoneNumber =aspUser.PhoneNumber,
                PhoneNumberConfirmed =aspUser.PhoneNumberConfirmed,
                TwoFactorEnabled =aspUser.TwoFactorEnabled,
                UserName =aspUser.UserName,
                Photo = "data:image /; base64," + Convert.ToBase64String(aspUser.Photo)
            };
            user.LoginCount = db.LoginLogs.Where(u => u.UserId == aspUser.Id).Count();
            //user.LoginTime = db.LoginLogs.Where(u => u.UserId == aspUser.Id).OrderByDescending(u => u.LoginTime).First().LoginTime;

            return View(user);
        }

        // GET: Admin/NormalUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NormalUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NormalUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/NormalUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NormalUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NormalUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
