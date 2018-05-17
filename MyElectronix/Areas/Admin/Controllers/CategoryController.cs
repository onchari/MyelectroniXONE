using MyElectronix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("admin/[controller]")]
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }



        public ActionResult Create()
        {
            return View();
        }
    }
}