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
    public class NextOfKinController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /NextOfKin/

        public ActionResult Index()
        {
            return View(db.NextOfKin.ToList());
        }

        //
        // GET: /NextOfKin/Details/5

        public ActionResult Details(int id = 0)
        {
            NextOfKin nextofkin = db.NextOfKin.Find(id);
            if (nextofkin == null)
            {
                return HttpNotFound();
            }
            return View(nextofkin);
        }

        //
        // GET: /NextOfKin/Create

        public ActionResult Create(int id=0)
        {
            ViewBag.pupil = db.Pupils.Find(id);
            return View();
        }


        [HttpPost]
        public ActionResult Create(NextOfKin nextofkin)
        {
            if (ModelState.IsValid)
            {
                db.NextOfKin.Add(nextofkin);
                db.SaveChanges();
              
                return RedirectToAction("Index");
            }

            return View(nextofkin);
        }

        //
        // GET: /NextOfKin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextOfKin nextofkin = db.NextOfKin.Find(id);
            if (nextofkin == null)
            {
                return HttpNotFound();
            }
            return View(nextofkin);
        }

        //
        // POST: /NextOfKin/Edit/5

        [HttpPost]
        public ActionResult Edit(NextOfKin nextofkin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextofkin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextofkin);
        }

        //
        // GET: /NextOfKin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextOfKin nextofkin = db.NextOfKin.Find(id);
            if (nextofkin == null)
            {
                return HttpNotFound();
            }
            return View(nextofkin);
        }

        //
        // POST: /NextOfKin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextOfKin nextofkin = db.NextOfKin.Find(id);
            db.NextOfKin.Remove(nextofkin);
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