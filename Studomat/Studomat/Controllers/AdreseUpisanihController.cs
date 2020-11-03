using Algebra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdreseUpisanihController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Adrese_upisanihh);
        }
        public ActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Adrese_upisanih adrese_upisanih)
        {
            if (ModelState.IsValid)
            {
                db.Adrese_upisanihh.Add(adrese_upisanih);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adrese_upisanih);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            Adrese_upisanih adrese_upisanih = db.Adrese_upisanihh.Find(id);
            if (adrese_upisanih == null)
            { return HttpNotFound(); }
            return View(adrese_upisanih);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Adrese_upisanih adrese_upisanih)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adrese_upisanih).State = EntityState.Modified;
                db.SaveChanges();
               
                return View("Details",adrese_upisanih);
            }

            return View(adrese_upisanih);
        }



        public ActionResult Details(int? id)

        {
            Adrese_upisanih adrese_upisanih = db.Adrese_upisanihh.Find(id);
            return View(adrese_upisanih);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adrese_upisanih adrese_upisanih = db.Adrese_upisanihh.Find(id);

            if (adrese_upisanih == null)
            {
                return HttpNotFound();
            }
            return View(adrese_upisanih);
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Adrese_upisanih adrese_upisanih = db.Adrese_upisanihh.Find(id);

            db.Adrese_upisanihh.Remove(adrese_upisanih);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}