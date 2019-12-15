using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeddingApp.Models;

namespace WeddingApp.Controllers
{
    public class WeddingPackageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeddingPackage
        public ActionResult Index()
        {
            return View(db.WeddingPackages.ToList());
        }

        // GET: WeddingPackage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            if (weddingPackage == null)
            {
                return HttpNotFound();
            }
            return View(weddingPackage);
        }

        // GET: WeddingPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeddingPackage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WeddingPackage weddingPackage)
        {
            if (ModelState.IsValid)
            {
                db.WeddingPackages.Add(weddingPackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weddingPackage);
        }

        // GET: WeddingPackage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            if (weddingPackage == null)
            {
                return HttpNotFound();
            }
            return View(weddingPackage);
        }

        // POST: WeddingPackage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WeddingPackage weddingPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weddingPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weddingPackage);
        }

        // GET: WeddingPackage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            if (weddingPackage == null)
            {
                return HttpNotFound();
            }
            return View(weddingPackage);
        }

        // POST: WeddingPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeddingPackage weddingPackage = db.WeddingPackages.Find(id);
            db.WeddingPackages.Remove(weddingPackage);
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
