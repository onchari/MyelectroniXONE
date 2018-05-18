using MyElectronix.Areas.Admin.Models;
using MyElectronix.Models;
using System;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Route("admin/[controller]")]
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create()
        {
           return View();
        }

        

        public ActionResult Index()
        {
            return View();
        }

       
    }
}