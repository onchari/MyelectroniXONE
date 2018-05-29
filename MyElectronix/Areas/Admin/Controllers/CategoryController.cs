using MyElectronix.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = db.Categories
                            .OrderBy(e => e.CategoryName)
                            .Where(e => e.IsActive == true)
                            .Select(e => new CategoryViewModel()
                            {
                                CategoryName = e.CategoryName,
                                CategoryDescription = e.CategoryDescription,
                                IsActive = e.IsActive
                            });
            return View(categories.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if(model != null && this.ModelState.IsValid)
            {
                var cat = new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.CategoryDescription,
                    IsActive = model.IsActive
                };
                this.db.Categories.Add(cat);
                db.SaveChanges();
                //Display Notification message "Category created"
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}