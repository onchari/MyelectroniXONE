using MyElectronix.Areas.Admin.Models;
using MyElectronix.Areas.Admin.Models.CategoryModels;
using MyElectronix.Extensions;
using MyElectronix.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("admin/[controller]")]
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //GET : 
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Categories.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Category model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditCategoryViewModel model)
        {
            if(ModelState.IsValid && model != null)
            {
                var e = new Category()
                {
                    CategoryName = model.CategoryName,
                    Description = model.Description,
                    DateCreated = DateTime.Today,
                    IsActive = true,
                    CategoryIconId = model.CategoryIconId
                };


                db.Categories.Add(e);
                db.SaveChanges();
                this.AddNotification("Category Created Successfully.", NotificationType.SUCCESS);
                return RedirectToAction("Create");
            }
            return View(model);
        }

     

        public ActionResult Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
        }

        //GET : 
        public ActionResult Details(int? id)
        {
           if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.Categories.Find(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        

       

       

       
    }
}