using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Globus.Models;
namespace Globus.Controllers
{
    public class HomeController : Controller
    {
        DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var p = (from q in db.slides select new { slogan = q.slogan, des = q.des, link = q.link, image = q.image, no = q.no }).OrderBy(o => o.no).ToList();
            string slide = "";
            for (int i = 0; i < p.Count; i++) {
                slide += "<li>";
                slide +=" <img src=\""+p[i].image+"\" alt=\""+p[i].slogan+"\" />";
                slide +="  <div class=\"flex-caption\">";
                slide +="    <h1>"+p[i].slogan+"</h1>";
                slide +="<p>"+p[i].des+"</p>";
                slide +="   <a href=\""+p[i].link+"\" class=\"button\">Read more</a>";
                slide +="  </div>";
                slide +="</li>";
            }
            ViewBag.slide = slide;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
