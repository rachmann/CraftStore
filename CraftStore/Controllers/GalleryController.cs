using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CraftStore.Logic;
using NetArgot.DataStore;

namespace CraftStore.Controllers
{
    public class GalleryController : Controller
    {
        private Db db;

        public GalleryController()
        {
            db = new Db(ConnectionStrings.DefaultConnection.ConnectionString);
        }
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            ViewBag.Message = "My Blog page.";

            return View();
        }
        public ActionResult Post()
        {
            ViewBag.Message = "This discussion.";

            return View();
        }
        public ActionResult Community()
        {
            ViewBag.Message = "Community page.";

            return View();
        }
        public ActionResult Work()
        {
            ViewBag.Message = "Community page.";

            return View();
        }
        // GET: Gallery/Project/5
        public ActionResult Project(int id)
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Community page.";

            return View();
        }
        public ActionResult Portofolio()
        {
            ViewBag.Message = "Portofolio page.";

            return View();
        }

        
        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gallery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gallery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gallery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #region JSON Data Helpers
        //Get Categories
        public JsonResult GetCategoryList()
        {
            var model = db.GetCategoryList().Select(c => new SelectListItem { Text = c.CategoryName, Value = c.Id.ToString(CultureInfo.InvariantCulture) }).ToList();
            
            if (model.Any())
            {
                model.First().Selected = true;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //Get Items
        public JsonResult GetItemList()
        {
            var model = db.GetItemList().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(CultureInfo.InvariantCulture) }).ToList();

            if (model.Any())
            {
                model.First().Selected = true;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //Get PostTags
        public JsonResult GetPostTagList()
        {
            var model = db.GetPostTagList().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(CultureInfo.InvariantCulture) }).ToList();

            if (model.Any())
            {
                model.First().Selected = true;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //Get PostTags
        public JsonResult GetPostList()
        {
            var model = db.GetPostList().Select(i => new SelectListItem { Text = i.Subject, Value = i.Id.ToString(CultureInfo.InvariantCulture) }).ToList();

            if (model.Any())
            {
                model.First().Selected = true;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
