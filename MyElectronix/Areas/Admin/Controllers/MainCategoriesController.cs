using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyElectronix.Areas.Admin.Models;
using MyElectronix.Models;

namespace MyElectronix.Areas.Admin.Controllers
{
    public class MainCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/MainCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.MainCategories.ToListAsync());
        }

        // GET: Admin/MainCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = await db.MainCategories.FindAsync(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // GET: Admin/MainCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MainCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MainCategoryId,MainCategoryName,MainCategoryDescription")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                db.MainCategories.Add(mainCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainCategory);
        }

        // GET: Admin/MainCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = await db.MainCategories.FindAsync(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // POST: Admin/MainCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MainCategoryId,MainCategoryName,MainCategoryDescription")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainCategory);
        }

        // GET: Admin/MainCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCategory mainCategory = await db.MainCategories.FindAsync(id);
            if (mainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mainCategory);
        }

        // POST: Admin/MainCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainCategory mainCategory = await db.MainCategories.FindAsync(id);
            db.MainCategories.Remove(mainCategory);
            await db.SaveChangesAsync();
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
