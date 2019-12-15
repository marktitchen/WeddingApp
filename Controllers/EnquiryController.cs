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
    public class EnquiryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enquiry
        public ActionResult Index()
        {
            var enquiries = db.Enquiries.Include(e => e.EnquiryCategory);
            return View(enquiries.ToList());
        }

        // GET: Enquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        // GET: Enquiry/Create
        public ActionResult Create()
        {
            ViewBag.EnquiryCategoryId = new SelectList(db.EnquiryCategories, "Id", "Name");
            return View();
        }

        // POST: Enquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,EnquiryCategoryId")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                db.Enquiries.Add(enquiry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnquiryCategoryId = new SelectList(db.EnquiryCategories, "Id", "Name", enquiry.EnquiryCategoryId);
            return View(enquiry);
        }

        // GET: Enquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnquiryCategoryId = new SelectList(db.EnquiryCategories, "Id", "Name", enquiry.EnquiryCategoryId);
            return View(enquiry);
        }

        // POST: Enquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,EnquiryCategoryId")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnquiryCategoryId = new SelectList(db.EnquiryCategories, "Id", "Name", enquiry.EnquiryCategoryId);
            return View(enquiry);
        }

        // GET: Enquiry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        // POST: Enquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enquiry enquiry = db.Enquiries.Find(id);
            db.Enquiries.Remove(enquiry);
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
