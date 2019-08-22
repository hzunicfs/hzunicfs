using Algebra.Models.Pretrazivanje.VMPredavac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Models
{
    [Authorize(Roles = "Admin")]
    public class VMPredavacController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PredavacIAdresa
        public ActionResult Index()
        {
            VMPredavac_Pre VMPredavac_Pre = new VMPredavac_Pre
            {
                IEAdresepredavaca = db.Adrese_predavacaa.ToList(),
                IEPredavaci = db.Predavacii.ToList()
            };

            return View(VMPredavac_Pre);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(VMPredavac_Pre VMPredavac_Pre)
        {
            var pretrazivanje = new VMPredavac_Log();
            {
            VMPredavac_Pre.IEPredavaci = pretrazivanje.IEPredavaci(VMPredavac_Pre);
            VMPredavac_Pre.IEAdresepredavaca = db.Adrese_predavacaa.ToList();
            }
            return View(VMPredavac_Pre);
        }




        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(VMPredavac PredavacIAdresa)

        {   TempData["Osobna"] = PredavacIAdresa.Predavaci.Broj_osobne;
            TempData["OIB"] = PredavacIAdresa.Predavaci.OIB;
            TempData.Keep("OIB");
            TempData.Keep("Osobna");

            if (ModelState.IsValid)
            {
                db.Predavacii.Add(PredavacIAdresa.Predavaci);
                db.Adrese_predavacaa.Add(PredavacIAdresa.Adresepredavaca);
                db.SaveChanges();
                return RedirectToAction("Index", "VMPredavac");
            }
            return View(PredavacIAdresa);
        }

        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredavac PredavacIAdresa = new VMPredavac
            {
                Predavaci = db.Predavacii.Find(id),
                Adresepredavaca = db.Adrese_predavacaa.Find(id2)
            };
            if (PredavacIAdresa.Predavaci == null || PredavacIAdresa.Adresepredavaca == null) 
            { return HttpNotFound(); }
           
            return View(PredavacIAdresa);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VMPredavac PredavacIAdresa)

        {
          

            if (ModelState.IsValid)
            {
                db.Entry(PredavacIAdresa.Adresepredavaca).State = EntityState.Modified;
                db.Entry(PredavacIAdresa.Predavaci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "VMPredavac");
            }
            return View(PredavacIAdresa);
        }



        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMPredavac PredavacIAdresa = new VMPredavac
            {
                Predavaci = db.Predavacii.Find(id),
                Adresepredavaca = db.Adrese_predavacaa.Find(id2)
            };
            if (PredavacIAdresa.Predavaci == null || PredavacIAdresa.Adresepredavaca == null)
            { return HttpNotFound(); }
            return View(PredavacIAdresa);
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int? id2)
        {
            VMPredavac PredavacIAdresa = new VMPredavac
            {
                Predavaci = db.Predavacii.Find(id),
                Adresepredavaca = db.Adrese_predavacaa.Find(id2)
            };

            db.Adrese_predavacaa.Remove(PredavacIAdresa.Adresepredavaca);
            db.Predavacii.Remove(PredavacIAdresa.Predavaci);

            db.SaveChanges();
            return RedirectToAction("Index", "VMPredavac");
        }

        public ActionResult Details(int? id,int? id2)
        {
            if (id != null && id2 != null)
            {

                VMPredavac PredavacIAdresa = new VMPredavac
                {
                    Predavaci = db.Predavacii.Find(id),
                    IEAdresepredavaca = (from k in db.Adrese_predavacaa
                                        where k.AP_ID==id2
                                        select k).ToList()
                };
                if (PredavacIAdresa.IEAdresepredavaca == null)
                {
                    return HttpNotFound();
                }
                if (PredavacIAdresa.Predavaci == null)
                {
                    return HttpNotFound();
                }
                return View(PredavacIAdresa);
            }
            else
            {
                string id3 = TempData["OIB"].ToString();
                string id4 = TempData["Osobna"].ToString();
               
                TempData.Clear();
                if (id4 == null && id3 == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                VMPredavac PredavacIAdresa = new VMPredavac();
                if (id3 !=null)
                {
                    PredavacIAdresa.Predavaci = db.Predavacii.Where(i => i.OIB == id3).FirstOrDefault();
                }
                else if(id4!=null)
                {
                    PredavacIAdresa.Predavaci = db.Predavacii.Where(i => i.Broj_osobne == id4).FirstOrDefault();
                }

                PredavacIAdresa.IEAdresepredavaca = db.Adrese_predavacaa.ToList();

                if (PredavacIAdresa.IEAdresepredavaca == null || PredavacIAdresa.Predavaci == null)
                {
                    return HttpNotFound();
                }
              
                return View(PredavacIAdresa);
            }
   
        }

    }
}