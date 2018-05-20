using MyElectronix.Areas.Admin.Models;
using MyElectronix.Areas.Admin.Models.CategoryModels;
using MyElectronix.Extensions;
using MyElectronix.Models;
using System;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("admin/[controller]")]
    public class CategoryController : BaseController
    {
       

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

        public ActionResult Details(int? id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int? id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit([Bind(Include = "")] object modelClassEntity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            return View();
        }

       
    }
}