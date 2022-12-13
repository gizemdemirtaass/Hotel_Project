using Otel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Otel.Controllers
{
    public class MusteriKayitController : Controller
    {
        OtelEntities db = new OtelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.MusteriKayits.ToList());
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(MusteriKayit ekle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    db.MusteriKayits.Add(ekle);
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
                //var result = db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault();
                return View(db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Duzenle(int id, MusteriKayit duzenle)
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
                return View(db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, MusteriKayit sil)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    sil = db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault();
                    db.MusteriKayits.Remove(sil);
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