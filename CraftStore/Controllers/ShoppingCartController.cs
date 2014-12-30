using CraftStore.Models;
using Dapper;
using DapperExtensions;
using PagedList;
using PagedList.Mvc;
using NetArgot.Models;
using NetArgot.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using NetArgot.Identity;

namespace CraftStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IdentityDbContext _db = new IdentityDbContext();

        public string CartId
        {
            get
            {
                if (Session["CartId"] == null)
                {
                    Session["CartId"] = Guid.NewGuid().ToString();
                }
                return (string)Session["CartId"];
            }
            set
            {
                if (Session["CartId"] != null)
                    Session.Remove("CartId");
                Session["CartId"] = value;
            }
        }
        // GET: ShoppingCart
        public ActionResult Index(int page = 1, int filterCategory = 0, int filterLowPrice = 0, int filterHighPrice = 0)
        {
            var newAllCategory = 0;
            if(filterCategory > 0)
            {
                var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                pg.Predicates.Add(Predicates.Field<Category>(f => f.CategoryName, Operator.Eq, "All Categories"));

                var cat = _db.Connection.GetList<Category>(pg).FirstOrDefault();

                newAllCategory = cat.Id;
            }

            List<Category> dbCategoryItems = _db.Connection.GetList<Category>().ToList();

            List<Item> allCategoryItems = _db.Connection.GetList<Category>().ToList()
                    .Where(c => ((filterCategory == 0 || filterCategory == newAllCategory) || c.Id == filterCategory))
                    .SelectMany(d => d.Items)
                    .Where(i => (filterLowPrice == 0 || i.Price >= filterLowPrice) && (filterHighPrice == 0 || i.Price <= filterHighPrice) )
                    .ToList();

            var model = new ShoppingCartViewModel
            {
                Items = allCategoryItems.ToPagedList(page, 50),
                Categories = dbCategoryItems.Select(c => new SelectListItem { Text = c.CategoryName, Value = c.Id.ToString() }).ToList(),
                SelectedCategories = new List<int>(),
                WhatOthersBought = new List<Item>(),
                TotalCount = allCategoryItems.Count(),
                CartItems = GetCartItems()
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Catalog", model);
            }
            return View(model);
        }

        protected List<CartItem> GetCartItems()
        {
            var predicate = Predicates.Field<CartItem>(f => f.CartId, Operator.Eq, CartId);
            return _db.Connection.GetList<CartItem>(predicate).ToList();

//            return _db.CartItems.Where(c => c.CartId == CartId).ToList();
        }

        public ActionResult CartAddItem(int id)
        {
            // Get the matching cart and album instances
                    var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                    pg.Predicates.Add(Predicates.Field<CartItem>(f => f.CartId, Operator.Eq,CartId));
                    pg.Predicates.Add(Predicates.Field<CartItem>(f => f.ItemId, Operator.Eq, id));

                    var cartItem = _db.Connection.GetList<CartItem>(pg).FirstOrDefault();

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    ItemId = id,
                    CartId = CartId,
                    Quantity = 1,
                };
                _db.Connection.Insert(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Quantity++;
                _db.Connection.Update(cartItem);
            }

            return RedirectToAction("Index");
        }
        public ActionResult CartRemoveItem(int id)
        {
            // Get the cart
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CartItem>(f => f.CartId, Operator.Eq, CartId));
            pg.Predicates.Add(Predicates.Field<CartItem>(f => f.ItemId, Operator.Eq, id));

            var cartItem = _db.Connection.GetList<CartItem>(pg).FirstOrDefault();

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    _db.Connection.Update(cartItem);
                }
                else
                {
                    _db.Connection.Delete(cartItem);
                }
            }
            return RedirectToAction("Index");
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = GetCartItems().Sum(i => i.Quantity * i.Price);

            return total ?? decimal.Zero;
        }
        public void EmptyCart()
        {
            var pred = Predicates.Field<CartItem>(f => f.CartId, Operator.Eq, CartId);

            var cartItems = _db.Connection.GetList<CartItem>(pred);

            foreach (var cartItem in cartItems)
            {
                _db.Connection.Delete(cartItem);
            }
            // Save changes
            
        }
        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Connection.Get<Item>(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ShoppingCart/Create
        public ActionResult Cart()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        // GET: ShoppingCart/Create
        public ActionResult Checkout()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var cart = GetCartItems();
            foreach (var item in cart)
            {
                item.CartId = userName;
                _db.Connection.Update(item);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
