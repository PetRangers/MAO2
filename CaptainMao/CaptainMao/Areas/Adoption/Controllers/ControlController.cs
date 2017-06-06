using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Models;

namespace CaptainMao.Areas.Adoption.Controllers
{
    public class ControlController : Controller
    {
        MaoEntities db = new MaoEntities();
        // GET: Adoption/Control
        public ActionResult Categories(int? cityid,string search)
        {
            if (cityid != null)
            {
                ViewBag.cityid = cityid;
            }
            if (search != null)
            {
                ViewBag.search = search;
            }
            
            return PartialView(db.Categories.ToList());
        }

        public ActionResult Cities(int? categoryid, string search)
        {
            if (categoryid != null)
            {
                ViewBag.categoryid = categoryid;
            }
            if (search != null)
            {
                ViewBag.search = search;
            }
            return PartialView(db.Citys.ToList());
        }

        public ActionResult CateForWish(int? cityid, string search)
        {
            if (cityid != null)
            {
                ViewBag.cityid = cityid;
            }
            if (search != null)
            {
                ViewBag.search = search;
            }

            return PartialView(db.Categories.ToList());
        }

        public ActionResult CitiesForWish(int? categoryid, string search)
        {
            if (categoryid != null)
            {
                ViewBag.categoryid = categoryid;
            }
            if (search != null)
            {
                ViewBag.search = search;
            }
            return PartialView(db.Citys.ToList());
        }
    }
}