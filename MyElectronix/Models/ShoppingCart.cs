using MyElectronix.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext storeDb = new ApplicationDbContext();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCardId(context);
            return cart;
        }

        public List<Cart> GetCartItems()
        {
            return storeDb.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
           
        }

        internal decimal GetTotal()
        {
            decimal? total = (from c in storeDb.Carts
                              where c.CartId == ShoppingCartId
                              select (int?)c.Count *
                              c.Product.ProductUnitPrice).Sum();

            return total ?? decimal.Zero;
        }


        public void AddToCart(Product addedProduct)
        {
            //get matching cart and product instance
            var cartItem = storeDb.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == addedProduct.ProductId);
            if(cartItem == null)
            {
                //create new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductId = addedProduct.ProductId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDb.Carts.Add(cartItem);
            }
            else
            {
                //if the item exist in the cart
                cartItem.Count++;
            }
            storeDb.SaveChanges();
        }

        public int GetCount()
        {
            int? count = (from c in storeDb.Carts
                          where c.CartId == ShoppingCartId
                          select (int?)c.Count).Sum();

            //Return zero if all entries are null
            return count ?? 0;
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = storeDb.Carts.Single(c => c.CartId == ShoppingCartId && c.RecordId == id);
            int itemCount = 0;
            if(cartItem != null)
            {
                if(cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDb.Carts.Remove(cartItem);
                }

                storeDb.SaveChanges();
            }
            return itemCount;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

       public string GetCardId(HttpContextBase context)
        {
            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                context.Session[CartSessionKey] = context.User.Identity.Name;
            }
            else
            {
                Guid tempCartId = Guid.NewGuid();
                context.Session[CartSessionKey] = tempCartId.ToString();
            }
            return context.Session[CartSessionKey].ToString();
        }
    }
}