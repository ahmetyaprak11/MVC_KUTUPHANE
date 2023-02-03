using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KUTUPHANE.Models.Entity; //SQL sorgularını bizim için yapacak olan Entity Framework'unu tanımladık.

namespace MVC_KUTUPHANE.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); // Modelimize ait yeni bir nesne oluşturuyoruz. Bunu db adlı değişkene atıyoruz. Tablomuza ulaşmamızı sağlıyor.   
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList(); //Kategori tablomuzdaki değerleri bize liste şeklinde getirmeyi sağladık. "degerler" adlı değişkene atadık. 
            return View(degerler); // Daha sonra bu "degerler" i bize döndürmesini istedik.
        }
        [HttpGet]
        public ActionResult KategoriEkle() //bunu yapmazsak safyayı çağırdığımızda db ye boş bir ekleme yapıyor.
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI p)  //ActionResult ile metod oluşturup "View" sayfası ile ilişkilendirip işlem yapıyoruz. Bu metod bir parametre alacak. Bu parametre hangi tablo ile işlem yapacaksa onu yazıyoruz. "p" dediğimiz yere istediğimizi yazabiliyoruz.
        {
            db.TBLKATEGORI.Add(p); //"p" den gelecek olan değerleri ekleyecek. Bu değerleri eklemenin "View" sayfasından yakalayacağız.
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var silincek = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(silincek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}