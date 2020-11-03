using Algebra.Models.Pretrazivanje.VMPredbiljezbe;
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
    
    public class VMPredbiljezbaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Predbiljezba
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            VMPredbiljezbe_Pre VMPredbiljezba_Pre = new VMPredbiljezbe_Pre();
            VMPredbiljezba_Pre.IEPredbiljezba = db.Predbiljezbaa.ToList();
          
            return View(VMPredbiljezba_Pre);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(VMPredbiljezbe_Pre VMPredbiljezba_Pre)
        {
            var pretrazivanje = new VMPredbiljezbe_Log();
            {
                VMPredbiljezba_Pre.IEPredbiljezba = pretrazivanje.IEPredbiljezba(VMPredbiljezba_Pre);
               
            }
            return View(VMPredbiljezba_Pre);

        }
        public ActionResult Create(int? OS_ID)
        {
            TempData["OS_ID"] = OS_ID;
            TempData.Keep("OS_ID");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(VMPredbiljezba VMPredbiljezba)

        {
            
            TempData.Keep("OS_ID");
            if (ModelState.IsValid)
            {
                db.Predbiljezbaa.Add(VMPredbiljezba.Predbiljezba);
                db.SaveChanges();
                TempData.Clear();
                TempData["Predbiljezba"] = VMPredbiljezba;
                return RedirectToAction("Potvrda");
            }

            return View(VMPredbiljezba);
        }

        public ActionResult Potvrda()
        {
            
            VMPredbiljezba VMPredbiljezba = new VMPredbiljezba();
            VMPredbiljezba = TempData["Predbiljezba"] as VMPredbiljezba;
        
            return View(VMPredbiljezba);
        }







        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredbiljezba VMPredbiljezba = new VMPredbiljezba();

            VMPredbiljezba.Predbiljezba = db.Predbiljezbaa.Find(id);

            return View(VMPredbiljezba);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredbiljezba VMPredbiljezba = new VMPredbiljezba();
            {
                VMPredbiljezba.Predbiljezba = db.Predbiljezbaa.Find(id);
                if (VMPredbiljezba.Predbiljezba == null)
                { return HttpNotFound(); }

                return View(VMPredbiljezba);
            };
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredbiljezba VMPredbiljezba = new VMPredbiljezba();
            {
                VMPredbiljezba.Predbiljezba = db.Predbiljezbaa.Find(id);
                db.Predbiljezbaa.Remove(VMPredbiljezba.Predbiljezba);
                db.SaveChanges();
                return RedirectToAction("Index", "VMPredbiljezba");
            };

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredbiljezba VMPredbiljezba = new VMPredbiljezba();
            {
                VMPredbiljezba.Predbiljezba = db.Predbiljezbaa.Find(id);
            }
                if (VMPredbiljezba.Predbiljezba == null)
            { return HttpNotFound(); }

            return View(VMPredbiljezba);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VMPredbiljezba VMPredbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VMPredbiljezba.Predbiljezba).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","VMPredbiljezba");
            }
            return View(VMPredbiljezba);
        }

    }
}