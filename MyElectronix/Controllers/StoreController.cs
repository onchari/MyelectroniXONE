using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Store/Browse
        public string Browse(string product)
        {
            string message = HttpUtility.HtmlEncode("Store.Browse, Product = " + product);
            return message;
        }

        public string Details()
        {
            return " Details";
        }
    }
}