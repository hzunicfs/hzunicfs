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
    public class SeminariController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Seminari
        public ActionResult Seminari()
        {
            return View(db.Seminarii);
        }

        //GET:Create
        public ActionResult Create()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Create(Seminari seminari)
        { if (ModelState.IsValid)
            {
                db.Seminarii.Add(seminari);
                db.SaveChanges();
                return RedirectToAction("Seminari");
            }
            return View(seminari);
        }
        public ActionResult Edit(string id)
        {
            if(id==null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminari seminari = db.Seminarii.Find(id);
            if(seminari==null)
            { return HttpNotFound(); }
            return View(seminari);
        }
        [HttpPost]
        public ActionResult Edit (Seminari seminari)
        {
            if(ModelState.IsValid)
            {
                db.Entry(seminari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Seminari");
            }
            return View(seminari);
        }
        public ActionResult Delete(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminari seminari = db.Seminarii.Find(id);
            if(seminari==null)
            {
                return HttpNotFound();
            }
            return View(seminari);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Seminari seminari = db.Seminarii.Find(id);
            db.Seminarii.Remove(seminari);
            db.SaveChanges();
            return RedirectToAction("Seminari");
        }
    }
}