using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kalinabiri.Models;
using System.IO;
using PagedList;

namespace Kalinabiri.Controllers
{
    public class PupilController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Pupil/

        public ActionResult Index(int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(db.Pupils.OrderBy(a=>a.PupilClass).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Report()
        {
            var Pupils = db.Pupils.Include(t => t.parent);
            return View("Report", Pupils.ToList());
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Report");
        }
        //
        // GET: /Pupil/Details/5

        public ActionResult Details(int id = 0)
        {
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            return View(pupil);
        }

        //
        // GET: /Pupil/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pupil/Create

        [HttpPost]
        public ActionResult Create(Pupil pupil, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                string[] AllowedExtensions = new[] { ".jpg", ".png","jpeg" };
                if (file.ContentLength > 0)
                {


                    if (!AllowedExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        //ModelState.AddModelError("Photo", "Please upload valid extensions(jpeg,jpg or png)");
                        TempData["Success"] = "Please upload valid photo types (eg jpeg ,jpg or png)";
                        return RedirectToAction("Create");
                    }
                    else
                    {

                        db.Pupils.Add(pupil);
                        pupil.ContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        file.InputStream.Read(fileBytes, 0, file.ContentLength);

                        pupil.Photo = fileBytes;

                        db.SaveChanges();
                        TempData["Success"] = "Record Added";
                        return RedirectToAction("Index");

                    }

                }
                if (file.ContentLength< 0)
                {
                    TempData["Success"] = "Please select photo";
                    return RedirectToAction("Create");
                }
            }


            return View(pupil);
        }

        //
        // GET: /Pupil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            return View(pupil);
        }

        //
        // POST: /Pupil/Edit/5

        [HttpPost]
        public ActionResult Edit(Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pupil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pupil);
        }

        //
        // GET: /Pupil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pupil pupil = db.Pupils.Find(id);
            if (pupil == null)
            {
                return HttpNotFound();
            }
            return View(pupil);
        }

        //
        // POST: /Pupil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pupil pupil = db.Pupils.Find(id);
            db.Pupils.Remove(pupil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public FileContentResult GetImage(int pupilID)
        {
            Pupil pupil = db.Pupils.FirstOrDefault(p => p.PupilID == pupilID);
            if (pupil != null)
            {
                return File(pupil.Photo, pupil.ContentType);
            }
            else
            {
                return null;
            }
        }
    }
}