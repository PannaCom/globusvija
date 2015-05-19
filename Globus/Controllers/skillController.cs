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
    public class skillController : Controller
    {
        private DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();

        //
        // GET: /skill/

        public ActionResult Index()
        {
            return View(db.skills.ToList());
        }

        //
        // GET: /skill/Details/5

        public ActionResult Details(int id = 0)
        {
            skill skill = db.skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // GET: /skill/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /skill/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(skill skill)
        {
            if (ModelState.IsValid)
            {
                db.skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        //
        // GET: /skill/Edit/5

        public ActionResult Edit(int id = 0)
        {
            skill skill = db.skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // POST: /skill/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        //
        // GET: /skill/Delete/5

        public ActionResult Delete(int id = 0)
        {
            skill skill = db.skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        //
        // POST: /skill/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skill skill = db.skills.Find(id);
            db.skills.Remove(skill);
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