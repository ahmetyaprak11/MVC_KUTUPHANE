using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MVC_KUTUPHANE.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            // var degerler = db.TBLUYELER.ToList();
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle() //bunu yapmazsak safyayı çağırdığımızda db ye boş bir ekleme yapıyor.
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)  //ActionResult ile metod oluşturup "View" sayfası ile ilişkilendirip işlem yapıyoruz. Bu metod bir parametre alacak. Bu parametre hangi tablo ile işlem yapacaksa onu yazıyoruz. "p" dediğimiz yere istediğimizi yazabiliyoruz.
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }

            db.TBLUYELER.Add(p); //"p" den gelecek olan değerleri ekleyecek. Bu değerleri eklemenin "View" sayfasından yakalayacağız.
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}