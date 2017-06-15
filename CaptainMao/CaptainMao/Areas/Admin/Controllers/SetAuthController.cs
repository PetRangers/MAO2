using CaptainMao.Areas.Admin.Models;
using CaptainMao.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Admin.Controllers
{
    public class SetAuthController : Controller
    {
        // GET: Admin/SetAuth
        public ActionResult SetAuth()
        {
            MaoEntities db = new MaoEntities();

            var allUsers = db.AspNetUsers.ToArray();

            
            List<SetAuthViewModel> setAuthList = new List<SetAuthViewModel>();

            foreach (var u in allUsers)
            {
                SetAuthViewModel setAuth = new SetAuthViewModel
                {
                    Id=u.Id, Experience=u.Experience, Name=u.LastName+" "+u.FirstName, UserName=u.UserName
                };
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


    }
}