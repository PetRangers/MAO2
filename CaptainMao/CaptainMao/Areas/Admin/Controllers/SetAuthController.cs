using CaptainMao.Areas.Admin.Models;
using CaptainMao.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class SetAuthController : Controller
    {
        MaoEntities db = new MaoEntities();


        // GET: Admin/SetAuth
        public ActionResult SetAuth()
        {
            var allUsers = db.AspNetUsers.ToArray();

            
            List<SetAuthViewModel> setAuthList = new List<SetAuthViewModel>();

            foreach (var u in allUsers)
            {
                SetAuthViewModel setAuth = new SetAuthViewModel
                {
                    Id=u.Id, Experience=u.Experience, UserName=u.UserName
                };
                if (u.LastName!=null)
                {
                    setAuth.Name = u.LastName + " " + u.FirstName;
                }
                else
                {
                    setAuth.Name = db.StoreInfoes.Where(s => s.StoreId == u.Id).First().StoreName;
                }

                var uRoles = u.AspNetRoles;
                List<string> roleList = new List<string>();
                foreach (var r in uRoles)
                {
                    roleList.Add(r.Name);
                }
                setAuth.IsAdmin = roleList.Contains("Admin");
                setAuth.IsMaster = roleList.Contains("Master");
                setAuth.IsStore = roleList.Contains("Store");
                setAuth.IsNormal = roleList.Contains("Normal");
                setAuth.IsInactivated = roleList.Contains("Inactivated");

                string boardList = "";
                foreach (var b in u.Boards)
                {
                    boardList += b.BoardName + " ";
                }
                setAuth.MasterOfBoards = boardList;

                setAuthList.Add(setAuth);
            }

            return View(setAuthList);
        }


        // GET: Admin/Edit
        [HttpPost]
        public ActionResult EditAuth(SetAuthViewModel m)
        {
            var user = db.AspNetUsers.Where(u => u.Id == m.Id).First();
            var userRoles = db.AspNetRoles.Where(r=>r.AspNetUsers.Contains(user));
            string roles = "";
            foreach (var r in userRoles)
            {
                roles += r.Name;
            }

            if (m.IsAdmin && !roles.Contains("Admin"))
            {
                db.AspNetUsers.Where(u => u.Id == m.Id).First().AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Admin").First());
            }
            else if (!m.IsAdmin && roles.Contains("Admin"))
            {
                db.AspNetUsers.Where(u => u.Id == m.Id).First().AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Admin").First());
            }

            db.SaveChanges();

            return RedirectToAction("SetAuth", "SetAuth", new { area = "Admin" });
        }

    }
}