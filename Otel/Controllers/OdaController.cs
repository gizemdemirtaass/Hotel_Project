using Otel.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Otel.Controllers
{
    public class OdaController : Controller
    {
        
            OtelEntities1 db = new OtelEntities1();

            [HttpGet] 
            public ActionResult Index() 
            {
                return View(db.Odalars.ToList());
            }
            [HttpGet] 
            public ActionResult Yeni()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Yeni(Odalar ekle)
            {
                try
                {
                    using (OtelEntities1 db = new OtelEntities1())
                    {
                        db.Odalars.Add(ekle);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return View();
                }
            }
            [HttpGet]
            public ActionResult Duzenle(int id)
            {
                using (OtelEntities1 db = new OtelEntities1())
                {
                    return View(db.Odalars.Where(x => x.OdaNo == id).FirstOrDefault());
                }
            }
            [HttpPost]
            public ActionResult Duzenle(int id, Odalar duzenle)
            {
                try
                {
                    using (OtelEntities1 db = new OtelEntities1())
                    {
                        db.Entry(duzenle).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {

                    return View();
                }
            }
            [HttpGet]
            public ActionResult Delete(int id)
            {
                using (OtelEntities1 db = new OtelEntities1())
                {
                    return View(db.Odalars.Where(x => x.OdaNo == id).FirstOrDefault());
                }
            }
            [HttpPost]
            public ActionResult Delete(int id, Odalar sil)
            {
                try
                {
                    using (OtelEntities1 db = new OtelEntities1())
                    {
                        sil = db.Odalars.Where(x => x.OdaNo == id).FirstOrDefault();
                        db.Odalars.Remove(sil);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {

                    return View();
                }
            }
        }
}