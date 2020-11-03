using Algebra.Models.Pretrazivanje.VMUpisani;
using Algebra.Models;
using Algebra.Models.Validacije;
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
    [Authorize(Roles = "Admin")]
    public class VMUpisaniController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: VMUpisani
        public ActionResult Index()
        {
            VMUpisani_Pre VMUpisani_Pre = new VMUpisani_Pre
            {
                IEAdresaupisanih = db.Adrese_upisanihh.ToList(),
            };

            VMUpisani_Pre.IEUpisani = db.Upisanii.ToList();
            VMUpisani_Pre.IEUpisi = db.Upisii.ToList();
            VMUpisani_Pre.IEUpisanihBroj = db.UpisanihBrojj.ToList();
            return View(VMUpisani_Pre);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(VMUpisani_Pre VMUpisani_Pre)
        {
            var pretrazivanje = new VMUpisani_Log();
            {
                VMUpisani_Pre.IEUpisani = pretrazivanje.IEUpisani(VMUpisani_Pre);
                VMUpisani_Pre.IEAdresaupisanih = db.Adrese_upisanihh.ToList();
                VMUpisani_Pre.IEUpisanihBroj = db.UpisanihBrojj.ToList();
            }

          return View(VMUpisani_Pre);
        }




        public ActionResult ListaUpisanih(int? id)
        {
            VMUpisani model = new VMUpisani
            {

                IEUpisani = db.Upisanii.ToList(),

                IEUpisi = (from k in db.Upisii
                          where k.OS_ID == id
                          select k).ToList(),
                IEAdresaupisanih = db.Adrese_upisanihh.ToList()
            };


            return View(model);
        }   
      
        public ActionResult Create(int? OS_ID)
        {
            TempData["OS_ID"] = OS_ID;
            TempData.Keep("OS_ID");
           return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(VMUpisani VMUpisani)

        {

            TempData.Keep("OS_ID");
            

       

            if (ModelState.IsValid)
            {
                db.Upisanii.Add(VMUpisani.Upisani);
                db.Adrese_upisanihh.Add(VMUpisani.Adreseupisanih);
                db.Upisii.Add(VMUpisani.Upisi);

                if ((db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == VMUpisani.BrojUpisanih.OS_ID)) != null)

                {
                    VMUpisani.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == VMUpisani.BrojUpisanih.OS_ID);
                    VMUpisani.BrojUpisanih.Brojac++;
                    db.Entry(VMUpisani.BrojUpisanih).State = EntityState.Modified;
                }
                else
                {
                    VMUpisani.BrojUpisanih.Brojac = 1;
                    db.BrojUpisanihh.Add(VMUpisani.BrojUpisanih);
                }
               db.SaveChanges();
                VMUpisani.Upisani = db.Upisanii.FirstOrDefault(x => x.OIB == VMUpisani.Upisani.OIB);


                VMUpisani.UpisanihBroj.Brojac = 1;
                VMUpisani.UpisanihBroj.Upisani_ID = VMUpisani.Upisani.Upisani_ID;
                db.UpisanihBrojj.Add(VMUpisani.UpisanihBroj);
                db.SaveChanges();

                TempData.Clear();
                return RedirectToAction("IndexPretrazivanje", "VMOtvoreniSeminari");
            }

            
            return View(VMUpisani);
        }


        public ActionResult Edit(int? id,int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMUpisani VMUpisani = new VMUpisani();
            {
                VMUpisani.Upisani = db.Upisanii.Find(id);
                VMUpisani.Adreseupisanih = db.Adrese_upisanihh.Find(id2);
            };

            if (VMUpisani.Upisani == null || VMUpisani.Adreseupisanih == null)
            { return HttpNotFound(); }
            return View(VMUpisani);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VMUpisani VMUpisani)
        {
           

            if (ModelState.IsValid)
            {
                db.Entry(VMUpisani.Upisani).State = EntityState.Modified;
                db.Entry(VMUpisani.Adreseupisanih).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "VMUpisani");
            }
            return View(VMUpisani);
        }



        public ActionResult DeleteUpisanog(int id, int id2)
        {
            VMUpisani VMUpisani = new VMUpisani();

            VMUpisani.Upisani = db.Upisanii.Find(id);

            VMUpisani.Upisi = db.Upisii.Find(id,id2);
            VMUpisani.BrojUpisanih=db.BrojUpisanihh.FirstOrDefault(x=>x.OS_ID==id2);
            VMUpisani.UpisanihBroj = db.UpisanihBrojj.FirstOrDefault(x => x.Upisani_ID == id);
            return View(VMUpisani);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("DeleteUpisanog")]
        public ActionResult DeleteConfirmed(int id,int id2)
        {
            VMUpisani VMUpisani = new VMUpisani();
            VMUpisani.Upisi = db.Upisii.Find(id,id2);
            db.Upisii.Remove(VMUpisani.Upisi);
            VMUpisani.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == id2);
            VMUpisani.BrojUpisanih.Brojac--;
            db.Entry(VMUpisani.BrojUpisanih).State = EntityState.Modified;
            VMUpisani.UpisanihBroj = db.UpisanihBrojj.FirstOrDefault(x => x.Upisani_ID == id);
            VMUpisani.UpisanihBroj.Brojac--;
            db.Entry(VMUpisani.UpisanihBroj).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("ListaUpisanih", "VMUpisani",new {id});
        }




        public ActionResult Delete(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMUpisani VMUpisani = new VMUpisani();
            {
                VMUpisani.Upisani = db.Upisanii.Find(id);
                VMUpisani.Adreseupisanih = db.Adrese_upisanihh.Find(id2);
               
              
            };

            if (VMUpisani.Upisani == null || VMUpisani.Adreseupisanih == null)
            { return HttpNotFound(); }
            return View(VMUpisani);
        }
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id, int? id2)
        {
            VMUpisani VMUpisani = new VMUpisani();
            {
                VMUpisani.Upisani = db.Upisanii.Find(id);
                VMUpisani.Adreseupisanih = db.Adrese_upisanihh.Find(id2);
            };
            db.Adrese_upisanihh.Remove(VMUpisani.Adreseupisanih);
            db.Upisanii.Remove(VMUpisani.Upisani);
            VMUpisani.IEBrojUpisanih = db.BrojUpisanihh.ToList();
            VMUpisani.IEUpisanihBroj = db.UpisanihBrojj.ToList();
            VMUpisani.IEUpisi = db.Upisii.Where(x => x.Upisani_ID == VMUpisani.Upisani.Upisani_ID);
            foreach (var item in VMUpisani.IEUpisi)
            {
                foreach (var meti in VMUpisani.IEBrojUpisanih.Where(meti=>meti.OS_ID==item.OS_ID))
                {
                    
                    db.BrojUpisanihh.Remove(VMUpisani.BrojUpisanih);
                }
                foreach (var meti in VMUpisani.IEUpisanihBroj.Where(meti => meti.Upisani_ID == item.Upisani_ID))
                {
                    db.UpisanihBrojj.Remove(VMUpisani.UpisanihBroj);
                }



                VMUpisani.Upisi= db.Upisii.Find(item.Upisani_ID, item.OS_ID);
                db.Upisii.Remove(VMUpisani.Upisi);
            }
            
            db.SaveChanges();
            return RedirectToAction("Index", "VMUpisani");
        }

        public ActionResult Details(int? id, int? id2)
        {


            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMUpisani VMUpisani = new VMUpisani

            {
                Upisani = db.Upisanii.Find(id),
                Adreseupisanih = db.Adrese_upisanihh.Find(id2)
            };
            if (VMUpisani.Adreseupisanih == null || VMUpisani.Upisani == null)
            {
                return HttpNotFound();
            }
            
        return View(VMUpisani);


        }

        public ActionResult DetailsPostoji(string id1,string id2)
        {
           
            TempData.Keep("OS_ID");
            if (id1== null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMUpisani VMUpisani = new VMUpisani();
            if (id1 != null)
            {
                VMUpisani.Upisani = db.Upisanii.Where(i => i.OIB == id1).FirstOrDefault();
                TempData["Upisani_ID"] = VMUpisani.Upisani.Upisani_ID;


            }
            else if (id2 != null)
            {
                VMUpisani.Upisani= db.Upisanii.Where(i => i.Broj_osobne == id2).FirstOrDefault();
                TempData["Upisani_ID"] = VMUpisani.Upisani.Upisani_ID;
            }

            VMUpisani.IEAdresaupisanih = db.Adrese_upisanihh.ToList();

            if (VMUpisani.Upisani == null || VMUpisani.IEAdresaupisanih == null)
            {
                return HttpNotFound();
            }
          
            return View(VMUpisani);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DetailsPostoji(VMUpisani VMUpisani)


        {
            TempData.Keep("OS_ID");
            TempData.Keep("Upisani_ID");
            if (ModelState.IsValid)
            {
                db.Upisii.Add(VMUpisani.Upisi);
                int OS_ID = int.Parse(TempData["OS_ID"].ToString());
                int Upi_ID = int.Parse(TempData["Upisani_ID"].ToString());
               
                if (db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == OS_ID) != null)
                {
                    VMUpisani.BrojUpisanih = db.BrojUpisanihh.FirstOrDefault(x => x.OS_ID == OS_ID);
                    VMUpisani.BrojUpisanih.Brojac++;
                    db.Entry(VMUpisani.BrojUpisanih).State = EntityState.Modified;
                }
                else
                {
                    VMUpisani.BrojUpisanih.Brojac = 1;
                    VMUpisani.BrojUpisanih.OS_ID = OS_ID;
                    db.BrojUpisanihh.Add(VMUpisani.BrojUpisanih);
                }

           
                if (db.UpisanihBrojj.FirstOrDefault(x => x.Upisani_ID == Upi_ID) != null)
                {
                    VMUpisani.UpisanihBroj = db.UpisanihBrojj.FirstOrDefault(x => x.Upisani_ID == Upi_ID);
                    VMUpisani.UpisanihBroj.Brojac++;
                    db.Entry(VMUpisani.UpisanihBroj).State = EntityState.Modified;
                }
                else
                {
                    VMUpisani.UpisanihBroj.Brojac = 1;
                    VMUpisani.UpisanihBroj.Upisani_ID = Upi_ID;
                    db.UpisanihBrojj.Add(VMUpisani.UpisanihBroj);
                }
                 db.SaveChanges();
                TempData.Clear();
                return RedirectToAction("IndexUpisi", "VMOtvoreniSeminari");
            }

           
            TempData.Keep("OS_ID");
            int Upisani_ID = VMUpisani.Upisi.Upisani_ID;

            VMUpisani.Upisani = db.Upisanii.Find(Upisani_ID); 
            
            VMUpisani.IEAdresaupisanih = db.Adrese_upisanihh.ToList();

            if (VMUpisani.Upisani == null || VMUpisani.IEAdresaupisanih == null)
            {
                return HttpNotFound();
            }
           
            return View(VMUpisani);
        }
    }
}