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
    public class visionController : Controller
    {
        private DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();

        //
        // GET: /vision/

        public ActionResult Index()
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            return View(db.visions.ToList());
        }

        //
        // GET: /vision/Details/5

        public ActionResult Details(int id = 0)
        {
            vision vision = db.visions.Find(id);
            if (vision == null)
            {
                return HttpNotFound();
            }
            return View(vision);
        }

        //
        // GET: /vision/Create

        public ActionResult Create()
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            return View();
        }

        //
        // POST: /vision/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vision vision)
        {
            if (ModelState.IsValid)
            {
                db.visions.Add(vision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vision);
        }

        //
        // GET: /vision/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            vision vision = db.visions.Find(id);
            if (vision == null)
            {
                return HttpNotFound();
            }
            return View(vision);
        }

        //
        // POST: /vision/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(vision vision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vision);
        }

        //
        // GET: /vision/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Config.getCookie("logged") == "") return RedirectToAction("Login", "Admin");
            vision vision = db.visions.Find(id);
            if (vision == null)
            {
                return HttpNotFound();
            }
            return View(vision);
        }

        //
        // POST: /vision/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vision vision = db.visions.Find(id);
            db.visions.Remove(vision);
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