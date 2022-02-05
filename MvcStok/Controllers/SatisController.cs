using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entitiy;
namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeniSatis()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(TBL_SATISLAR p)
        {
            db.TBL_SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}