using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;
namespace MvcStok.Controllers

{
    public class MusteriController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        // GET: Musteri
        public ActionResult Index(string p)

        {
            var degerler = from d in db.TBL_MUSTERİLER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERİAD.Contains(p));
            }
            return View(degerler.ToList());
        //    var degerler = db.TBL_MUSTERİLER.ToList();
        //    return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERİLER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_MUSTERİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var mstr = db.TBL_MUSTERİLER.Find(id);
            db.TBL_MUSTERİLER.Remove(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBL_MUSTERİLER.Find(id);
            return View("MusteriGetir", mstr);
        }
        public ActionResult Guncelle(TBL_MUSTERİLER p1)
        {
            var mstr = db.TBL_MUSTERİLER.Find(p1.MUSTERİID);
            mstr.MUSTERİAD = p1.MUSTERİAD;
            mstr.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}