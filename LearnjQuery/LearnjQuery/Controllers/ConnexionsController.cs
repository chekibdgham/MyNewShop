using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LearnjQuery.DAL;
using LearnjQuery.Models;

namespace LearnjQuery.Controllers
{
    public class ConnexionsController : Controller
    {
        private LearnjQueryContext db = new LearnjQueryContext();

        // GET: Connexions
        public ActionResult Index()
        {
            return View(db.Connexions.ToList());
        }

        // GET: Connexions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connexion connexion = db.Connexions.Find(id);
            if (connexion == null)
            {
                return HttpNotFound();
            }
            return View(connexion);
        }

        // GET: Connexions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Connexions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnexionId,UserName,PassWord")] Connexion connexion)
        {
            if (ModelState.IsValid)
            {
                db.Connexions.Add(connexion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(connexion);
        }

        // GET: Connexions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connexion connexion = db.Connexions.Find(id);
            if (connexion == null)
            {
                return HttpNotFound();
            }
            return View(connexion);
        }

        // POST: Connexions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnexionId,UserName,PassWord")] Connexion connexion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connexion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(connexion);
        }

        // GET: Connexions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connexion connexion = db.Connexions.Find(id);
            if (connexion == null)
            {
                return HttpNotFound();
            }
            return View(connexion);
        }

        // POST: Connexions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Connexion connexion = db.Connexions.Find(id);
            db.Connexions.Remove(connexion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
