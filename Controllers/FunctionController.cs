using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeddingApp.Models;
using WeddingApp.Models.ViewModel;

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

            var model = new FunctionViewModel
            {
                Function = function,
                WeddingPackages = db.WeddingPackages.ToList()
            };
            
            return View(model);
        }

        // GET: Function/Create
        public ActionResult Create()
        {
            var weddingPackage = db.WeddingPackages.ToList();
            var model = new FunctionViewModel
            {
                WeddingPackages = weddingPackage
            };
            return View(model);
        }

        // POST: Function/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FunctionViewModel functionVM)
        {
            var function = new Function
            {
                FunctionDate = functionVM.Function.FunctionDate,
                DateAdded = functionVM.Function.DateAdded,
                Notes = functionVM.Function.Notes,
                WeddingPackageId = functionVM.Function.WeddingPackageId,
                WeddingPackage = functionVM.Function.WeddingPackage
            };
            
            if (ModelState.IsValid)
            {
                db.Functions.Add(function);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            functionVM.WeddingPackages = db.WeddingPackages.ToList();

            return View(functionVM);

            
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

            var model = new FunctionViewModel
            {
                Function = function,
                WeddingPackages = db.WeddingPackages.ToList()
            };
            
            return View(model);
        }

        // POST: Function/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FunctionViewModel functionVM)
        {
            var function = new Function
            {
                Id = functionVM.Function.Id,
                FunctionDate = functionVM.Function.FunctionDate,
                DateAdded = functionVM.Function.DateAdded,
                Notes = functionVM.Function.Notes,
                WeddingPackageId = functionVM.Function.WeddingPackageId,
                WeddingPackage = functionVM.Function.WeddingPackage
            };

            if (ModelState.IsValid)
            {
                
                db.Entry(function).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            functionVM.WeddingPackages = db.WeddingPackages.ToList();
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

            var model = new FunctionViewModel
            {
                Function = function,
                WeddingPackages = db.WeddingPackages.ToList()
            };

            return View(model);
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
