using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalinabiri.Models;
using PagedList;

namespace Kalinabiri.Controllers
{
    public class ParentController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Parent/

        public ActionResult Index(int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(db.Parents.OrderBy(a => a.FirstName).ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Parent/Details/5

        public ActionResult Details(int id = 0)
        {
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        //
        // GET: /Parent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Parent/Create

        [HttpPost]
        public ActionResult Create(Parent parent)
        {
            if (ModelState.IsValid)
            {
                db.Parents.Add(parent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parent);
        }

        //
        // GET: /Parent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        //
        // POST: /Parent/Edit/5

        [HttpPost]
        public ActionResult Edit(Parent parent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parent);
        }

        //
        // GET: /Parent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        //
        // POST: /Parent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent parent = db.Parents.Find(id);
            db.Parents.Remove(parent);
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