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

                setAuth.IsBoardDogMaster = (db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID == u.Id) ? true : false;
                setAuth.IsBoardCatMaster = (db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID == u.Id) ? true : false;
                //string boardList = "";
                //foreach (var b in u.Boards)
                //{
                //    boardList += b.BoardName + " ";
                //}
                //setAuth.MasterOfBoards = boardList;

                setAuthList.Add(setAuth);
            }

            return View(setAuthList);
        }


        // GET: Admin/EditAuth
        [HttpGet]
        public ActionResult EditAuth(string id)
        {
            var user = db.AspNetUsers.Where(u => u.Id == id).First();

            SetAuthViewModel setAuth = new SetAuthViewModel
            {
                Id=id,
                Experience=user.Experience,
                UserName=user.UserName
            };
            if (user.LastName != null)
            {
                setAuth.Name = user.LastName + " " + user.FirstName;
            }
            else
            {
                setAuth.Name = db.StoreInfoes.Where(s => s.StoreId == id).First().StoreName;
            }
            var uRoles = user.AspNetRoles;
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

            setAuth.IsBoardDogMaster = (db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID == id) ? true : false;
            setAuth.IsBoardCatMaster = (db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID == id) ? true : false;
            //string boardList = "";
            //foreach (var b in user.Boards)
            //{
            //    boardList += b.BoardName + " ";
            //}
            //setAuth.MasterOfBoards = boardList;
            
            return View(setAuth);
        }

        // GET: Admin/EditAuth
        [HttpPost]
        public ActionResult EditAuth(SetAuthViewModel model)
        {
            var user = db.AspNetUsers.Where(u => u.Id == model.Id).First();
            user.Experience = model.Experience;

            var userRoles = user.AspNetRoles.ToList();
            string roles = "";
            foreach (var r in userRoles)
            {
                roles += r.Name;
            }

            if (model.IsAdmin && !roles.Contains("Admin"))
            {
                user.AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Admin").First());
            }
            else if (!model.IsAdmin && roles.Contains("Admin"))
            {
                user.AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Admin").First());
            }

            if (model.IsMaster && !roles.Contains("Master"))
            {
                user.AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Master").First());
            }
            else if (!model.IsMaster && roles.Contains("Master"))
            {
                user.AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Master").First());
            }

            if (model.IsStore && !roles.Contains("Store"))
            {
                user.AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Store").First());
            }
            else if (!model.IsStore && roles.Contains("Store"))
            {
                user.AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Store").First());
            }

            if (model.IsNormal && !roles.Contains("Normal"))
            {
                user.AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Normal").First());
            }
            else if (!model.IsNormal && roles.Contains("Normal"))
            {
                user.AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Normal").First());
            }

            if (model.IsInactivated && !roles.Contains("Inactivated"))
            {
                user.AspNetRoles.Add(db.AspNetRoles.Where(r => r.Name == "Inactivated").First());
            }
            else if (!model.IsInactivated && roles.Contains("Inactivated"))
            {
                user.AspNetRoles.Remove(db.AspNetRoles.Where(r => r.Name == "Inactivated").First());
            }

            if (model.IsBoardDogMaster && (db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID != model.Id))
            {
                db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID = model.Id;
            }
            else if (!model.IsBoardDogMaster && (db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID == model.Id))
            {
                db.Boards.Where(b => b.BoardName == "狗").First().MasterUserID = null;
            }

            if (model.IsBoardCatMaster && (db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID != model.Id))
            {
                db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID = model.Id;
            }
            else if (!model.IsBoardCatMaster && (db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID == model.Id))
            {
                db.Boards.Where(b => b.BoardName == "貓").First().MasterUserID = null;
            }

            db.SaveChanges();

            return RedirectToAction("SetAuth", "SetAuth", new { area = "Admin" });
        }

    }
}