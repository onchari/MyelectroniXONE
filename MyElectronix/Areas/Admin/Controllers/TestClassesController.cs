using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyElectronix.Areas.Admin.Models;
using MyElectronix.Models;

namespace MyElectronix.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("admin/[controller]")]
    public class TestClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TestClasses
        public ActionResult Index()
        {
            return View(db.TestClasses.ToList());
        }

        // GET: Admin/TestClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // GET: Admin/TestClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TestClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestClassId,Name")] TestClass testClass)
        {
            if (ModelState.IsValid)
            {
                db.TestClasses.Add(testClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testClass);
        }

        // GET: Admin/TestClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // POST: Admin/TestClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestClassId,Name")] TestClass testClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testClass);
        }

        // GET: Admin/TestClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return HttpNotFound();
            }
            return View(testClass);
        }

        // POST: Admin/TestClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestClass testClass = db.TestClasses.Find(id);
            db.TestClasses.Remove(testClass);
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
