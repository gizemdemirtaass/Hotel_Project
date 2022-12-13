using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otel.Models;
using Microsoft.SqlServer;

namespace Otel.Controllers
{
    public class AdminController : Controller
    {
       
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Odalar()
        {
            return View();
        }
        public ActionResult Servisler()
        {
            return View();
        }
    }
}