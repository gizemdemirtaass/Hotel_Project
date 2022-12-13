using Otel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer;

namespace Otel.Controllers
{
    public class RegisterController : Controller
    {

       
        // GET: Register
        OtelEntities db = new OtelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.UserMasters.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(UserMaster ekle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    db.UserMasters.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Index","Admin");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}