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
    public class EnquiryCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnquiryCategory
        public ActionResult Index()
        {
            return View(db.EnquiryCategories.ToList());
        }

        // GET: EnquiryCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryCategory enquiryCategory = db.EnquiryCategories.Find(id);
            if (enquiryCategory == null)
            {
                return HttpNotFound();
            }
            return View(enquiryCategory);
        }

        // GET: EnquiryCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnquiryCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] EnquiryCategory enquiryCategory)
        {
            if (ModelState.IsValid)
            {
                db.EnquiryCategories.Add(enquiryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enquiryCategory);
        }

        // GET: EnquiryCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryCategory enquiryCategory = db.EnquiryCategories.Find(id);
            if (enquiryCategory == null)
            {
                return HttpNotFound();
            }
            return View(enquiryCategory);
        }

        // POST: EnquiryCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] EnquiryCategory enquiryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enquiryCategory);
        }

        // GET: EnquiryCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnquiryCategory enquiryCategory = db.EnquiryCategories.Find(id);
            if (enquiryCategory == null)
            {
                return HttpNotFound();
            }
            return View(enquiryCategory);
        }

        // POST: EnquiryCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnquiryCategory enquiryCategory = db.EnquiryCategories.Find(id);
            db.EnquiryCategories.Remove(enquiryCategory);
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
