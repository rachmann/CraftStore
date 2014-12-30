using NetArgot.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CraftStore.Models
{
    public class ShoppingCartViewModel
    {
        public IPagedList<Item> Items { get; set; }
        public List<Item> WhatOthersBought { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<int> SelectedCategories { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public string CurrentCategory { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}