﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Globus.Models;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Globus.Controllers
{
    public class newsController : Controller
    {
        private DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();

        //
        // GET: /news/

        public ActionResult Index()
        {
            return View(db.news.ToList());
        }

        //
        // GET: /news/Details/5

        public ActionResult Details(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // GET: /news/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /news/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(news news)
        {
            if (ModelState.IsValid)
            {
                db.news.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public string UploadImageProcess(HttpPostedFileBase file, string filename)
        {
            string physicalPath = HttpContext.Server.MapPath("../" + Config.NewsImagePath + "\\");
            string nameFile = String.Format("{0}.jpg", Guid.NewGuid().ToString());
            int countFile = Request.Files.Count;
            string fullPath = physicalPath + System.IO.Path.GetFileName(nameFile);
            for (int i = 0; i < countFile; i++)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                Request.Files[i].SaveAs(fullPath);
                break;
            }
            string ok = resizeImage(Config.imgWidthBigNews, Config.imgHeightBigNews, fullPath, Config.NewsImagePath + "/" + nameFile);
            return Config.NewsImagePath + "/" + nameFile;
        }
        public string resizeImage(int maxWidth, int maxHeight, string fullPath, string path)
        {

            var image = System.Drawing.Image.FromFile(fullPath);
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratioX);
            var newHeight = (int)(image.Height * ratioY);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics thumbGraph = Graphics.FromImage(newImage);

            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
            image.Dispose();

            string fileRelativePath = path;// "newsizeimages/" + maxWidth + Path.GetFileName(path);
            newImage.Save(HttpContext.Server.MapPath(fileRelativePath), newImage.RawFormat);
            return fileRelativePath;
        }
        //
        // GET: /news/Edit/5

        public ActionResult Edit(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /news/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(news news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /news/Delete/5

        public ActionResult Delete(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /news/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.news.Find(id);
            db.news.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}