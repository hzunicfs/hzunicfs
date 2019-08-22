using Algebra.Models.Pretrazivanje.VMOtvoreniSeminari;
using Algebra.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Controllers
{
    public class VMOtvoreniSeminariController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize(Roles = "Admin")]
        public ActionResult IndexPretrazivanje()
        {
            VMOtvoreniSeminari_Pre VMOtvoreniSeminari_Pre = new VMOtvoreniSeminari_Pre
            {
                IESeminari = db.Seminarii.ToList(),
                IEPredavaci = db.Predavacii.ToList(),
                IEAdresaodrzavanja = db.Adresa_odrzavanjaa.ToList(),
                IEOtvoreniseminari = db.Otvoreni_seminarii.ToList(),
                IEUpisi = db.Upisii.ToList(),
                IEBrojUpisanih = db.BrojUpisanihh.ToList(),
                SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
                {
                    Value = k.AO_ID.ToString(),
                    Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
                }),

                SLPredavaci = db.Predavacii.Select(k => new SelectListItem
                {
                    Value = k.Predavaci_ID.ToString(),
                    Text = k.Ime + " " + k.Prezime
                }),
                SLSeminari = db.Seminarii.Select(k => new SelectListItem
                {
                    Value = k.Seminar_ID.ToString(),
                    Text = k.Naziv
                })
            };
        return View(VMOtvoreniSeminari_Pre);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult IndexPretrazivanje(VMOtvoreniSeminari_Pre VMOtvoreniSeminari_Pre)
        {
            var pretrazivanje = new VMOtvoreniSeminari_Log();
            {
                VMOtvoreniSeminari_Pre.IEOtvoreniseminari = pretrazivanje.IEOtvoreniseminari(VMOtvoreniSeminari_Pre);
                VMOtvoreniSeminari_Pre.IESeminari = db.Seminarii.ToList();
                VMOtvoreniSeminari_Pre.IEPredavaci = db.Predavacii.ToList();
                VMOtvoreniSeminari_Pre.IEAdresaodrzavanja = db.Adresa_odrzavanjaa.ToList();
                VMOtvoreniSeminari_Pre.IEUpisi = db.Upisii.ToList();
                VMOtvoreniSeminari_Pre.IEBrojUpisanih = db.BrojUpisanihh.ToList();

                VMOtvoreniSeminari_Pre.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
                {
                    Value = k.AO_ID.ToString(),
                    Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
                });

                VMOtvoreniSeminari_Pre.SLPredavaci = db.Predavacii.Select(k => new SelectListItem
                {
                    Value = k.Predavaci_ID.ToString(),
                    Text = k.Ime + " " + k.Prezime
                });
                VMOtvoreniSeminari_Pre.SLSeminari = db.Seminarii.Select(k => new SelectListItem
                {
                    Value = k.Seminar_ID.ToString(),
                    Text = k.Naziv
                });
            }
            return View(VMOtvoreniSeminari_Pre);

        }



     
        public ActionResult IndexUpisi()
        {
            VMOtvoreniSeminari_Pre VMOtvoreniSeminari_Pre = new VMOtvoreniSeminari_Pre();
            VMOtvoreniSeminari_Pre.IESeminari = db.Seminarii.ToList();
            VMOtvoreniSeminari_Pre.IEPredavaci = db.Predavacii.ToList();
            VMOtvoreniSeminari_Pre.IEAdresaodrzavanja = db.Adresa_odrzavanjaa.ToList();
            VMOtvoreniSeminari_Pre.IEOtvoreniseminari = db.Otvoreni_seminarii.ToList();
            VMOtvoreniSeminari_Pre.SLSeminari = db.Seminarii.Select(k => new SelectListItem
            {
                Value = k.Seminar_ID.ToString(),
                Text = k.Naziv
            });
            VMOtvoreniSeminari_Pre.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
            {
                Value = k.AO_ID.ToString(),
                Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
            });

            return View(VMOtvoreniSeminari_Pre);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult IndexUpisi(VMOtvoreniSeminari_Pre VMOtvoreniSeminari_Pre)
        {
            var model = new VMOtvoreniSeminari_Log();
            {
                VMOtvoreniSeminari_Pre.IEOtvoreniseminari = model.IEOtvoreniseminari(VMOtvoreniSeminari_Pre);
                VMOtvoreniSeminari_Pre.IESeminari = db.Seminarii.ToList();
                VMOtvoreniSeminari_Pre.IEPredavaci = db.Predavacii.ToList();
                VMOtvoreniSeminari_Pre.IEAdresaodrzavanja = db.Adresa_odrzavanjaa.ToList();
                VMOtvoreniSeminari_Pre.SLSeminari = db.Seminarii.Select(k => new SelectListItem
                {
                    Value = k.Seminar_ID.ToString(),
                    Text = k.Naziv
                });
                VMOtvoreniSeminari_Pre.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
                {
                    Value = k.AO_ID.ToString(),
                    Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
                });
            }
            return View(model);
        }





        [Authorize(Roles = "Admin")]
        public ActionResult CreatePretrazivanje()
        {

            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            model.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
            {
                Value = k.AO_ID.ToString(),
                Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
            });
            model.SLPredavaci = db.Predavacii.Select(k => new SelectListItem
            { Value = k.Predavaci_ID.ToString(),
                Text = k.Ime + " " + k.Prezime
            });
            model.SLSeminari = db.Seminarii.Select(k => new SelectListItem
            {
                Value = k.Seminar_ID.ToString(),
                Text = k.Naziv
            });
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreatePretrazivanje(VMOtvoreniSeminari model)

        {

            if (ModelState.IsValid)
            {
                db.Otvoreni_seminarii.Add(model.Otvoreniseminari);
                db.SaveChanges();
                return RedirectToAction("IndexPretrazivanje", "VMOtvoreniSeminari");
            }

            model.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem
            {
                Value = k.AO_ID.ToString(),
                Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
            });


            model.SLPredavaci = db.Predavacii.Select(k => new SelectListItem
            {
                Value = k.Predavaci_ID.ToString(),
                Text = k.Ime + " " + k.Prezime
            });

            model.SLSeminari = db.Seminarii.Select(k => new SelectListItem
            {
                Value = k.Seminar_ID.ToString(),
                Text = k.Naziv
            });

            return View(model);
        }



        [Authorize(Roles = "Admin")]
        public ActionResult EditPretrazivanje(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            {
                model.Otvoreniseminari = db.Otvoreni_seminarii.Find(id);
                model.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem

                {
                    Value = k.AO_ID.ToString(),
                    Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
                });


                model.SLPredavaci = db.Predavacii.Select(k => new SelectListItem
                {
                    Value = k.Predavaci_ID.ToString(),
                    Text = k.Ime + " " + k.Prezime
                });

                model.SLSeminari = db.Seminarii.Select(k => new SelectListItem
                {
                    Value = k.Seminar_ID.ToString(),
                    Text = k.Naziv
                });
            };

            if (model.Otvoreniseminari == null)

            { return HttpNotFound(); }

            if (model.SLSeminari == null)
            { return HttpNotFound(); }
            if (model.SLPredavaci == null)
            { return HttpNotFound(); }
            if (model.SLAdresaodrzavanja == null)
            { return HttpNotFound(); }


            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditPretrazivanje(VMOtvoreniSeminari model)
        {
            if (ModelState.IsValid)
            {

                db.Entry(model.Otvoreniseminari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPretrazivanje", "VMOtvoreniSeminari");
            }
            model.SLAdresaodrzavanja = db.Adresa_odrzavanjaa.Select(k => new SelectListItem

            {
                Value = k.AO_ID.ToString(),
                Text = k.Ulica + " " + k.Kucni_broj + ", " + k.Grad
            });


            model.SLPredavaci = db.Predavacii.Select(k => new SelectListItem
            {
                Value = k.Predavaci_ID.ToString(),
                Text = k.Ime + " " + k.Prezime
            });

            model.SLSeminari = db.Seminarii.Select(k => new SelectListItem
            {
                Value = k.Seminar_ID.ToString(),
                Text = k.Naziv
            });

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id, int? id2, int? id3, int id4)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            {
                model.Otvoreniseminari = db.Otvoreni_seminarii.Find(id);
                if (model.Otvoreniseminari == null)
                { return HttpNotFound(); }

                model.Adresaodrzavanja = db.Adresa_odrzavanjaa.Find(id2);
                if (model.Adresaodrzavanja == null)
                { return HttpNotFound(); }

                model.Predavaci = db.Predavacii.Find(id3);
                if (model.Predavaci == null)
                { return HttpNotFound(); }

                model.Seminari = db.Seminarii.Find(id4);
                if (model.Seminari == null)
                { return HttpNotFound(); }

                return View(model);
            };
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            {
                List<int> Upisanih = (from k in db.Upisii
                                      where k.OS_ID == id
                                      select k.Upisani_ID).ToList();
                model.Otvoreniseminari = db.Otvoreni_seminarii.Find(id);
                db.Otvoreni_seminarii.Remove(model.Otvoreniseminari);
                model.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == id);
                db.BrojUpisanihh.Remove(model.BrojUpisanih);
                model.IEUpisi = db.Upisii.Where(x => x.OS_ID == id);

                foreach (var item in model.IEUpisi)
                {
                    db.Upisii.Remove(db.Upisii.Find(item.Upisani_ID, item.OS_ID));
                }
                foreach (var item in Upisanih)
                { foreach (var meti in db.UpisanihBrojj.Where(x => x.Upisani_ID == item))
                    {
                        model.UpisanihBroj = db.UpisanihBrojj.FirstOrDefault(x => x.Upisani_ID == item);
                        model.UpisanihBroj.Brojac--;
                        db.Entry(model.UpisanihBroj).State = EntityState.Modified;

                    }


                }

                db.SaveChanges();
                return RedirectToAction("IndexPretrazivanje", "VMOtvoreniSeminari");
            }

        }
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsUpisani(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();

            model.IEUpisi = (from k in db.Upisii
                            where k.Upisani_ID == id
                            select k).ToList();

            model.IEOtvoreniseminari = db.Otvoreni_seminarii.ToList();
            if (model.IEOtvoreniseminari == null)
            { return HttpNotFound(); }

            model.IEAdresaodrzavanja = db.Adresa_odrzavanjaa.ToList();
            if (model.IEAdresaodrzavanja == null)
            { return HttpNotFound(); }

            model.IEPredavaci = db.Predavacii.ToList();
            if (model.IEPredavaci == null)
            { return HttpNotFound(); }

            model.IESeminari = db.Seminarii.ToList();
            if (model.IESeminari == null)
            { return HttpNotFound(); }

            return View(model);
        }
      
        public ActionResult DetailsUpisi(int? id, int? id2, int? id3, int? id4)

        {
            TempData["OS_ID"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            model.Otvoreniseminari = db.Otvoreni_seminarii.Find(id);
            if (model.Otvoreniseminari == null)
            { return HttpNotFound(); }

            model.Adresaodrzavanja = db.Adresa_odrzavanjaa.Find(id2);
            if (model.Adresaodrzavanja == null)
            { return HttpNotFound(); }

            model.Predavaci = db.Predavacii.Find(id3);
            if (model.Predavaci == null)
            { return HttpNotFound(); }

            model.Seminari = db.Seminarii.Find(id4);
            if (model.Seminari == null)
            { return HttpNotFound(); }

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsPretrazivanje(int? id, int? id2, int? id3, int? id4)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            model.Otvoreniseminari = db.Otvoreni_seminarii.Find(id);
            if (model.Otvoreniseminari == null)
            { return HttpNotFound(); }

            model.Adresaodrzavanja = db.Adresa_odrzavanjaa.Find(id2);
            if (model.Adresaodrzavanja == null)
            { return HttpNotFound(); }

            model.Predavaci = db.Predavacii.Find(id3);
            if (model.Predavaci == null)
            { return HttpNotFound(); }

            model.Seminari = db.Seminarii.Find(id4);
            if (model.Seminari == null)
            { return HttpNotFound(); }

            model.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == id);
           

            return View(model);
        }
       
        public ActionResult DetailsPredbiljezba(int? OS_ID)
        {
            if (OS_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMOtvoreniSeminari model = new VMOtvoreniSeminari();
            model.Otvoreniseminari = db.Otvoreni_seminarii.Find(OS_ID);
            if (model.Otvoreniseminari == null)
            { return HttpNotFound(); }

            model.Adresaodrzavanja = db.Adresa_odrzavanjaa.FirstOrDefault(x=>x.AO_ID==model.Otvoreniseminari.AO_ID);
            if (model.Adresaodrzavanja == null)
            { return HttpNotFound(); }

            model.Predavaci = db.Predavacii.FirstOrDefault(x => x.Predavaci_ID == model.Otvoreniseminari.Predavaci_ID);
            if (model.Predavaci == null)
            { return HttpNotFound(); }

            model.Seminari = db.Seminarii.FirstOrDefault(x => x.Seminar_ID == model.Otvoreniseminari.Seminar_ID);
            if (model.Seminari == null)
            { return HttpNotFound(); }

            model.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == model.Otvoreniseminari.OS_ID);
           

            return View(model);
        }

    }
}