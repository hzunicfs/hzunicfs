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
    [Authorize(Roles ="Admin")]
    public class AdresaOdrzavanjaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AdresaOdrzavanja
        public ActionResult Index()
        {
            return View(db.Adresa_odrzavanjaa);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Adresa_odrzavanja adresa_odrzavanja)
        {
            if (ModelState.IsValid)
            {
                db.Adresa_odrzavanjaa.Add(adresa_odrzavanja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresa_odrzavanja);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_odrzavanja adresa_odrzavanja = db.Adresa_odrzavanjaa.Find(id);
            if (adresa_odrzavanja == null)
            { return HttpNotFound(); }
            return View(adresa_odrzavanja);
        }
        [HttpPost]
        public ActionResult Edit(Adresa_odrzavanja adresa_odrzavanja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresa_odrzavanja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresa_odrzavanja);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_odrzavanja adresa_odrzavanja = db.Adresa_odrzavanjaa.Find(id); 
            if (adresa_odrzavanja == null)
            {
                return HttpNotFound();
            }
            return View(adresa_odrzavanja);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresa_odrzavanja adresa_odrzavanja = db.Adresa_odrzavanjaa.Find(id);
            db.Adresa_odrzavanjaa.Remove(adresa_odrzavanja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa_odrzavanja adresa_odrzavanja = db.Adresa_odrzavanjaa.Find(id);
            if (adresa_odrzavanja == null)
            {
                return HttpNotFound();
            }
            return View(adresa_odrzavanja);

        }

    }
}