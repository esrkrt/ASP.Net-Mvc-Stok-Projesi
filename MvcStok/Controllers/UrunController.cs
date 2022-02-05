using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;
namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBL_URUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        //urun ekleme
        [HttpPost]
        public ActionResult YeniUrun(TBL_URUNLER p1)
        {
            var ktg = db.TBL_KATEGORİLER.Where(m => m.KATEGORID == p1.TBL_KATEGORİLER.KATEGORID).FirstOrDefault();
            p1.TBL_KATEGORİLER = ktg;
            db.TBL_URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //urun silme
        public ActionResult Sil(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            db.TBL_URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBL_URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_KATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBL_URUNLER p1)
        {
            var urun = db.TBL_URUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.FIYAT = p1.FIYAT;
            var ktg = db.TBL_KATEGORİLER.Where(m => m.KATEGORID == p1.TBL_KATEGORİLER.KATEGORID).FirstOrDefault();
            urun.URUNKATEGORİ = ktg.KATEGORID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}