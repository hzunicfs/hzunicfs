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
    public class AdresePredavacaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            return View(db.Adrese_predavacaa);
        }
        public ActionResult Create()
        {
           
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Adresepredavaca adrese_predavaca)
        {
            if (ModelState.IsValid)
            {db.Adrese_predavacaa.Add(adrese_predavaca);
                    db.SaveChanges();
                    return RedirectToAction("Index"); }
       
            return View(adrese_predavaca);
        }

        public ActionResult Create2()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create2(Adresepredavaca adrese_predavaca)

        {
            if (ModelState.IsValid)
            {
                db.Adrese_predavacaa.Add(adrese_predavaca);
                db.SaveChanges();

                return RedirectToAction("Create2", "Predavaci",new { adrese_predavaca.AP_ID });
            }

            return View(adrese_predavaca);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresepredavaca adrese_predavaca = db.Adrese_predavacaa.Find(id);
            if (adrese_predavaca == null)
            { return HttpNotFound(); }
            return View(adrese_predavaca);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Adresepredavaca adrese_predavaca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adrese_predavaca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adrese_predavaca);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresepredavaca adrese_predavaca = db.Adrese_predavacaa.Find(id);

            if (adrese_predavaca == null)
            {
                return HttpNotFound();
            }
            return View(adrese_predavaca);
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           Adresepredavaca adrese_predavaca = db.Adrese_predavacaa.Find(id);

            db.Adrese_predavacaa.Remove(adrese_predavaca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresepredavaca adrese_predavaca = db.Adrese_predavacaa.Find(id);
            if (adrese_predavaca == null)
            {
                return HttpNotFound();
            }

            return View(adrese_predavaca);

        }
    }
}