using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KUTUPHANE.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        public ActionResult Resimyukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0 )
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        } 
    }
}