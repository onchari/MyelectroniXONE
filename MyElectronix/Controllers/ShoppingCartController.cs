using MyElectronix.Extensions;
using MyElectronix.Models;
using MyElectronix.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Controllers
{
   

    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

       
        

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            //retrieve the item from the database
            var addedProduct = db.Products.Single(p => p.ProductId == id);

            //add it to cart
            var cart = ShoppingCart.GetCart(HttpContext);
            cart.AddToCart(addedProduct);
            this.AddNotification("Added to cart successfully", NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            string productName = db.Carts.Single(i => i.RecordId == id).Product.ProductName;

            //Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            //Display confirmation
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + "has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);

        }

        //// GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}