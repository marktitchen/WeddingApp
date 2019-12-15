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
    public class FunctionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Function
        public ActionResult Index()
        {
            var functions = db.Functions.Include(f => f.WeddingPackage);
            return View(functions.ToList());
        }

        // GET: Function/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // GET: Function/Create
        public ActionResult Create()
        {
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name");
            return View();
        }

        // POST: Function/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FunctionDate,DateAdded,Notes,WeddingPackageId")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Functions.Add(function);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", function.WeddingPackageId);
            return View(function);
        }

        // GET: Function/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", function.WeddingPackageId);
            return View(function);
        }

        // POST: Function/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FunctionDate,DateAdded,Notes,WeddingPackageId")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Entry(function).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WeddingPackageId = new SelectList(db.WeddingPackages, "Id", "Name", function.WeddingPackageId);
            return View(function);
        }

        // GET: Function/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // POST: Function/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Function function = db.Functions.Find(id);
            db.Functions.Remove(function);
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
