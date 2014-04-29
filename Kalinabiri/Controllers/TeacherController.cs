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
    public class TeacherController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Teacher/

        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.House);
            return View(teachers.ToList());
        }


        public ActionResult Report()
        {
            var teachers = db.Teachers.Include(t => t.House);
            return View("Report",teachers.ToList());
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Report");
        }
        //
        // GET: /Teacher/Details/5

        public ActionResult Details(int id = 0)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        //
        // GET: /Teacher/Create

        public ActionResult Create()
        {
            ViewBag.HouseID = new SelectList(db.House, "HouseID", "Name");
            return View();
        }

        //
        // POST: /Teacher/Create

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseID = new SelectList(db.House, "HouseID", "Name", teacher.HouseID);
            return View(teacher);
        }

        //
        // GET: /Teacher/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseID = new SelectList(db.House, "HouseID", "Name", teacher.HouseID);
            return View(teacher);
        }

        //
        // POST: /Teacher/Edit/5

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseID = new SelectList(db.House, "HouseID", "Name", teacher.HouseID);
            return View(teacher);
        }

        //
        // GET: /Teacher/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        //
        // POST: /Teacher/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult AssignSubjectsToTeacher(int id = 0)
        {
            var mappings = db.Teachers.Find(id).SubjectAndTeacherMappings;
            ViewBag.Teacher = db.Teachers.Find(id);
            return View(mappings);
        }
        [HttpPost]
        public ActionResult AssignSubjectsToTeacher(SubjectAndTeacher subjectAndTeacher)
        {

            if (ModelState.IsValid)
            {
                db.SubjectAndTeacher.Add(subjectAndTeacher);
                db.SaveChanges();
                return RedirectToAction("AssignSubjectsToTeacher");
            }

            return View(subjectAndTeacher);

        }
    }
}