using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
namespace MVC_KUTUPHANE.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle() //bunu yapmazsak safyayı çağırdığımızda db ye boş bir ekleme yapıyor.
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)  //ActionResult ile metod oluşturup "View" sayfası ile ilişkilendirip işlem yapıyoruz. Bu metod bir parametre alacak. Bu parametre hangi tablo ile işlem yapacaksa onu yazıyoruz. "p" dediğimiz yere istediğimizi yazabiliyoruz.
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }

            db.TBLPERSONEL.Add(p); //"p" den gelecek olan değerleri ekleyecek. Bu değerleri eklemenin "View" sayfasından yakalayacağız.
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}