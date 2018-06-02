using MyElectronix.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var products = from p in db.Products
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper())
                || s.Category.CategoryName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;

                case "Price":
                    products = products.OrderBy(s => s.ProductUnitPrice);
                    break;

                case "price_desc":
                    products = products.OrderByDescending(s => s.ProductUnitPrice);
                    break;

                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }

        
    }
}