using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Globus.Controllers
{
    public class adminController : Controller
    {
        //
        // GET: /admin/

        public ActionResult Index()
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            return View();
        }
        public ActionResult Login() {
            return View();
        }
        public ActionResult Logout()
        {
            if (Request.Cookies["logged"] != null)
            {
                Response.Cookies["logged"].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            return View();
        }
    }
}
