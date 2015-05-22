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
            string news = "";
            try
            {
                var p2 = (from q in db.news select new { title = q.title, des = q.des, fullcontent = q.fullcontent, image = q.image, id = q.id }).OrderByDescending(o => o.id).Take(4).ToList();
                for (int i = 0; i < p2.Count; i++)
                {
                    var it=p2[i];
                    news+="<div class=\"four columns alpha\">";
                    news+="<img src=\""+it.image+"\" alt=\""+it.title+"\" class=\"alignnone scale-with-grid\"/>";
                    news+="<h3 class=\"smallmargin\">"+it.title+"</h3>";
                    news += "<p>" + Config.smoothDes(it.des) + "</p>";
                    news+="<p><a href=\"/news/"+Config.unicodeToNoMark(it.title)+"-"+it.id+"\" class=\"button\">Read more</a></p>";
                    news+="</div>";

                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.news = news;
            string vision = "";
            try
            {
                var p3 = (from q in db.visions select new { v1=q.vision1,d1=q.des1,v2=q.vision2,d2=q.des2,v3=q.vision3,d3=q.des3}).FirstOrDefault();
               
                    
                    vision += "<li>";
                    vision += "<img src=\"/Content/images/icon/date.png\"  class=\"alignleft\">";
                    vision +="<div class=\"lp\">";
                    vision += "<h3><a href=\"#\">"+p3.v1+"</a></h3>";
                    vision += "<span>" + p3.d1 + "</span>";                    
                    vision += "</div>";
                    vision += "</li>";
                    vision += "<li>";
                    vision += "<img src=\"/Content/images/icon/date.png\"  class=\"alignleft\">";
                    vision += "<div class=\"lp\">";
                    vision += "<h3><a href=\"#\">" + p3.v2 + "</a></h3>";
                    vision += "<span>" + p3.d2 + "</span>";
                    vision += "</div>";
                    vision += "</li>";
                    vision += "<li>";
                    vision += "<img src=\"/Content/images/icon/date.png\"  class=\"alignleft\">";
                    vision += "<div class=\"lp\">";
                    vision += "<h3><a href=\"#\">" + p3.v3 + "</a></h3>";
                    vision += "<span>" + p3.d3 + "</span>";
                    vision += "</div>";
                    vision += "</li>";

               
            }
            catch (Exception ex)
            {

            }
            ViewBag.vision = vision;
            string service = "";
            try
            {
                var p4 = (from q in db.services select new { name=q.name,id=q.id}).OrderBy(o => o.id).ToList();
                for (int i = 0; i < p4.Count; i++)
                {
                    var it = p4[i];
                    service += "<li>";
                    //service += "<img src=\"/Content/images/icon/date.png\"  class=\"alignleft\">";
                    service += "<div class=\"lp\">";
                    service += "<h2 class=\"trigger\"><span>"+it.name+"</span></h2>";//"<h3><a href=\"#\">" + it.name + "</a></h3>";
                    service += "</div>";
                    service += "</li>";

                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.service = service;
            return View();
        }
       
        public ActionResult About()
        {
            try
            {
                var p = (from q in db.abouts select new { title = q.title, des = q.des, fulllcontent = q.fullcontent,image=q.image }).FirstOrDefault();
                string about="";
                about += "<p><img src=\"" + p.image + "\" alt=\"" + p.title + "\" class=\"scale-with-grid\"/></p>";
                about+="<h3>"+p.title+"</h3>";
                about+="<p>"+p.des+"</p>";
                about += "<p>" + p.fulllcontent + "</p>";
                ViewBag.about = about;
                var p2 = (from q in db.skills select new { des = q.des, skill1 = q.skill1, des1 = q.des1, skill2 = q.skill2, des2 = q.des2, skill3 = q.skill3, des3 = q.des3}).FirstOrDefault();
                ViewBag.des = p2.des;
                ViewBag.skill1 = p2.skill1;
                ViewBag.skill2 = p2.skill2;
                ViewBag.skill3 = p2.skill3;
                ViewBag.des1 = p2.des1;
                ViewBag.des2 = p2.des2;
                ViewBag.des3 = p2.des3;

            }
            catch (Exception ex) { 

            }


            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
            var p = (from q in db.contacts select new { des = q.des, fullcontent = q.fullcontent }).FirstOrDefault();
            try
            {
                ViewBag.des = p.des;
                ViewBag.fullcontent = p.fullcontent;
            }
            catch (Exception ex) { 
            }
            return View();
        }
    }
}
