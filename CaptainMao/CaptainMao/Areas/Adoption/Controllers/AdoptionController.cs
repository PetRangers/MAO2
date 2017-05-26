using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Areas.Adoption.Controllers
{
    public class AdoptionController : Controller
    {
        [ChildActionOnly]
        public ActionResult Aside()
        {
            return View();
        }

        // GET: Adoption/Adoption
        public ActionResult Index()
        {
            return View();
        }

        // GET: Adoption/Adoption/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Adoption/Adoption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adoption/Adoption/Create
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

        // GET: Adoption/Adoption/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Adoption/Adoption/Edit/5
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

        // GET: Adoption/Adoption/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adoption/Adoption/Delete/5
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
