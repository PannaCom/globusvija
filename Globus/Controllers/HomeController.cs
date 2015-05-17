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
            string slide = "";
            try
            {
                var p = (from q in db.slides select new { slogan = q.slogan, des = q.des, link = q.link, image = q.image, no = q.no }).OrderBy(o => o.no).ToList();     
                for (int i = 0; i < p.Count; i++)
                {
                    slide += "<li>";
                    slide += " <img src=\"" + p[i].image + "\" alt=\"" + p[i].slogan + "\" />";
                    slide += "  <div class=\"flex-caption\">";
                    slide += "    <h1>" + p[i].slogan + "</h1>";
                    slide += "<p>" + p[i].des + "</p>";
                    slide += "   <a href=\"" + p[i].link + "\" class=\"button\">Read more</a>";
                    slide += "  </div>";
                    slide += "</li>";
                }
            }
            catch (Exception ex) { 
                
            }
            ViewBag.slide = slide;
            string about = "";
            try
            {
                var p1 = (from q in db.abouts select new { title = q.title, des = q.des, fullcontent = q.fullcontent, image = q.image,id=q.id}).OrderBy(o=>o.id).ToList();
                for (int i = 0; i < p1.Count; i++)
                {
                    about += "<hgroup>";
                    about += "<h2 class=\"smallmargin\">" + p1[i].title + "</h2>";
                    about += "<h3 class=\"customcolor\">" + p1[i].des + "</h3>";
                    about += "</hgroup>";
                    about += " <p>" + p1[i].fullcontent + "</p>";
                   
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.about = about;
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
