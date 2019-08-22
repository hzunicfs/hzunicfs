using Algebra.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Controllers
{
    public class UpisaniController : Controller
    { private ApplicationDbContext db = new ApplicationDbContext();

       

        // GET: kjhkjht
        public ActionResult Upisani()
        {
            return View(db.Upisanii);

        }
  public ActionResult Parcijalni_Adresa(string id)
        {
            
            Adrese_upisanih Parcijalna = db.Adrese_upisanihh.Find(id);
            ViewBag.Parcijalni = Parcijalna.Ulica +" "+ Parcijalna.Kucni_broj;
            return View("_Parcijalni");
        }

        public ActionResult Create()
        {
            List<string> Adrese_upisanih = (from k in db.Adrese_upisanihh
                                                     
                                             select k.Id_Adresa).ToList();
            ViewBag.Adresa_upisanih = Adrese_upisanih;
            return View();
        }
     

    }
}