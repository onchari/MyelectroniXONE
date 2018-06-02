using MyElectronix.Areas.Admin.Models;
using MyElectronix.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        //GET : Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var findById = db.Products.Find(id);
            if (findById == null)
            {
                return HttpNotFound();
            }
            return View(findById);
        }

        //GET : Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string name = product.ProductName;
                db.Products.Add(product);
                db.SaveChanges();
                this.AddNotification($"{name} has been added succesfully", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        //GET : Admin/Product/Details
       public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var findById = db.Products.Find(id);
            if(findById == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", findById.CategoryId);
            return View(findById);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification($"{product.ProductId} has been Edited", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //GET : Admin/Product/Delete/3
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var findById = db.Products.Find(id);
            if(findById == null)
            {
                return HttpNotFound();
            }

            return View(findById);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var findById = db.Products.Find(id);
            db.Products.Remove(findById);
            db.SaveChanges();

            this.AddNotification("Deleted Successfully", NotificationType.INFO);
            return RedirectToAction("Index");
        }
    }
}