using Algebra.Models;
using Algebra.Models.Pretrazivanje.VMSeminari;
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
    public class VMSeminariController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Seminari
        public ActionResult Seminari()
        {
            VMSeminari_Pre VMSeminari_Pre = new VMSeminari_Pre();
            VMSeminari_Pre.IESeminari = db.Seminarii.ToList();
            return View(VMSeminari_Pre);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Seminari(VMSeminari_Pre VMSeminari_Pre)
        {
           var pretrazivanje = new VMSeminari_Log();
            VMSeminari_Pre.IESeminari = pretrazivanje.IESeminari(VMSeminari_Pre);
            return View(VMSeminari_Pre);
        }


        public ActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(VMSeminari VMSeminari)
        {
            if (ModelState.IsValid)
            {
                db.Seminarii.Add(VMSeminari.Seminari);
                db.SaveChanges();
                return RedirectToAction("Seminari");
            }
            return View(VMSeminari);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMSeminari VMSeminari = new VMSeminari();
               VMSeminari.Seminari = db.Seminarii.Find(id);
            if (VMSeminari.Seminari== null)
            { return HttpNotFound(); }

            return View(VMSeminari);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VMSeminari VMseminari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VMseminari.Seminari).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Seminari");
            }
            return View(VMseminari);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMSeminari VMSeminari = new VMSeminari();
            VMSeminari.Seminari= db.Seminarii.Find(id);
            if (VMSeminari.Seminari == null)
            {
                return HttpNotFound();
            }
            return View(VMSeminari);
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VMSeminari VMSeminari = new VMSeminari();
            VMSeminari.Seminari = db.Seminarii.Find(id);
            db.Seminarii.Remove(VMSeminari.Seminari);
            db.SaveChanges();
            return RedirectToAction("Seminari");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMSeminari VMSeminari = new VMSeminari();
            VMSeminari.Seminari = db.Seminarii.Find(id);
            if (VMSeminari.Seminari == null)
            {
                return HttpNotFound();
            }
            return View(VMSeminari);

        }







    }





}