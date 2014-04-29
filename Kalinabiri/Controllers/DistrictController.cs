using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalinabiri.Models;

namespace Kalinabiri.Controllers
{
    public class DistrictController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /District/

        public ActionResult Index()
        {
            return View(db.Districts.ToList());
        }

        //
        // GET: /District/Details/5

        public ActionResult Details(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // GET: /District/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /District/Create

        [HttpPost]
        public ActionResult Create(District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(district);
        }

        //
        // GET: /District/Edit/5

        public ActionResult Edit(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // POST: /District/Edit/5

        [HttpPost]
        public ActionResult Edit(District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(district);
        }

        //
        // GET: /District/Delete/5

        public ActionResult Delete(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // POST: /District/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}