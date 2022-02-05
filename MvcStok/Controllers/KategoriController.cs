using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.TBL_KATEGORİLER.ToList();
            var degerler = db.TBL_KATEGORİLER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        //Kategori ekleme 
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORİLER p1)
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }
        
            db.TBL_KATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TBL_KATEGORİLER.Find(id);
            db.TBL_KATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORİLER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBL_KATEGORİLER p1)
        {
            var ktgr = db.TBL_KATEGORİLER.Find(p1.KATEGORID);
            ktgr.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}