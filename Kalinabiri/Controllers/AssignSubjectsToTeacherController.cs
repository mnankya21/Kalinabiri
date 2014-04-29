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
    public class AssignSubjectsToTeacherController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /TeacherAndSubject/

        public ActionResult Index()
        {
            return View(db.SupportStaff.ToList());
        }

        //
        // GET: /TeacherAndSubject/Details/5

        public ActionResult Details(int id = 0)
        {
            SupportStaff supportstaff = db.SupportStaff.Find(id);
            if (supportstaff == null)
            {
                return HttpNotFound();
            }
            return View(supportstaff);
        }

        //
        // GET: /TeacherAndSubject/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TeacherAndSubject/Create

        [HttpPost]
        public ActionResult Create(SupportStaff supportstaff)
        {
            if (ModelState.IsValid)
            {
                db.SupportStaff.Add(supportstaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supportstaff);
        }

        //
        // GET: /TeacherAndSubject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SupportStaff supportstaff = db.SupportStaff.Find(id);
            if (supportstaff == null)
            {
                return HttpNotFound();
            }
            return View(supportstaff);
        }

        //
        // POST: /TeacherAndSubject/Edit/5

        [HttpPost]
        public ActionResult Edit(SupportStaff supportstaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supportstaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supportstaff);
        }

        //
        // GET: /TeacherAndSubject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SupportStaff supportstaff = db.SupportStaff.Find(id);
            if (supportstaff == null)
            {
                return HttpNotFound();
            }
            return View(supportstaff);
        }

        //
        // POST: /TeacherAndSubject/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportStaff supportstaff = db.SupportStaff.Find(id);
            db.SupportStaff.Remove(supportstaff);
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