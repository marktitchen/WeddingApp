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
    public class WeddingDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeddingDetail
        public ActionResult Index()
        {
            var weddingDetails = db.WeddingDetails.Include(w => w.WeddingPackage);
            return View(weddingDetails.ToList());
        }

        // GET: WeddingDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingDetails weddingDetails = db.WeddingDetails.Find(id);
            if (weddingDetails == null)
            {
                return HttpNotFound();
            }
            return View(weddingDetails);
        }

        // GET: WeddingDetail/Create
        public ActionResult Create()
        {
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name");
            return View();
        }

        // POST: WeddingDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fee,NoOfGuest,WeddingPackageId")] WeddingDetails weddingDetails)
        {
            if (ModelState.IsValid)
            {
                db.WeddingDetails.Add(weddingDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", weddingDetails.WeddingPackageId);
            return View(weddingDetails);
        }

        // GET: WeddingDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingDetails weddingDetails = db.WeddingDetails.Find(id);
            if (weddingDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", weddingDetails.WeddingPackageId);
            return View(weddingDetails);
        }

        // POST: WeddingDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fee,NoOfGuest,WeddingPackageId")] WeddingDetails weddingDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weddingDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", weddingDetails.WeddingPackageId);
            return View(weddingDetails);
        }

        // GET: WeddingDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeddingDetails weddingDetails = db.WeddingDetails.Find(id);
            if (weddingDetails == null)
            {
                return HttpNotFound();
            }
            return View(weddingDetails);
        }

        // POST: WeddingDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeddingDetails weddingDetails = db.WeddingDetails.Find(id);
            db.WeddingDetails.Remove(weddingDetails);
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
