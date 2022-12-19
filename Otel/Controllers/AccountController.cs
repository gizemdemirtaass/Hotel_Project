using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Otel.Models;
using Microsoft.SqlServer.Server;

namespace Otel.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        

            [HttpPost]
            public ActionResult Login(User user)
            {
                using (OtelEntities1 db = new OtelEntities1()) 
                {
                    var result = db.UserMasters.Where(x => x.Username == user.Username && x.Password == user.Password1);
                    if (result.Count() != 0)
                    {
                        FormsAuthentication.SetAuthCookie(user.Username, false);  //persistant cookie = kalıcı cookie

                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        TempData["msg"] = "hatalı";  //controller arasında veri taşımaya yarayan bir komut ->TempData
                    }
                }
                return View();
            }
            public ActionResult Logout()
            {
                Session.Clear();
                FormsAuthentication.SignOut(); //formun üzerindeki tüm session ve cookileri temizle demek!!
                return View("Login"); //Login sayafasına yönlendir demek!!
            }
        }
}