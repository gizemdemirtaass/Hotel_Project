using Otel.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Otel.Controllers
{
    public class OdaController : Controller
    {
        
            OtelEntities db = new OtelEntities();

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
                    using (OtelEntities db = new OtelEntities())
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
                using (OtelEntities db = new OtelEntities())
                {
                    return View(db.Odalars.Where(x => x.OdaNo == id).FirstOrDefault());
                }
            }
            [HttpPost]
            public ActionResult Duzenle(int id, Odalar duzenle)
            {
                try
                {
                    using (OtelEntities db = new OtelEntities())
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
                using (OtelEntities db = new OtelEntities())
                {
                    return View(db.Odalars.Where(x => x.OdaNo == id).FirstOrDefault());
                }
            }
            [HttpPost]
            public ActionResult Delete(int id, Odalar sil)
            {
                try
                {
                    using (OtelEntities db = new OtelEntities())
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