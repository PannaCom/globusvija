using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Globus.Models;

namespace Globus.Controllers
{
    public class hotlineController : Controller
    {
        private DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();

        //
        // GET: /hotline/

        public ActionResult Index()
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            return View(db.hotlines.ToList());
        }

        //
        // GET: /hotline/Details/5

        public ActionResult Details(int id = 0)
        {
            hotline hotline = db.hotlines.Find(id);
            if (hotline == null)
            {
                return HttpNotFound();
            }
            return View(hotline);
        }

        //
        // GET: /hotline/Create

        public ActionResult Create()
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            return View();
        }

        //
        // POST: /hotline/Create

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(hotline hotline)
        {
            if (ModelState.IsValid)
            {
                db.hotlines.Add(hotline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotline);
        }

        //
        // GET: /hotline/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            hotline hotline = db.hotlines.Find(id);
            if (hotline == null)
            {
                return HttpNotFound();
            }
            return View(hotline);
        }

        //
        // POST: /hotline/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(hotline hotline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotline);
        }

        //
        // GET: /hotline/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            hotline hotline = db.hotlines.Find(id);
            if (hotline == null)
            {
                return HttpNotFound();
            }
            return View(hotline);
        }

        //
        // POST: /hotline/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hotline hotline = db.hotlines.Find(id);
            db.hotlines.Remove(hotline);
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