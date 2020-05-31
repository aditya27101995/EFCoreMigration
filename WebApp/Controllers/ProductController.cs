using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: ProductController
        public ActionResult Index()
        {
            // var data = db.products.ToList(); 
            List<Product> data = db.products.Select(p => p).ToList();
            return View(data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = db.categories.ToList();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            db.products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = db.categories.ToList();
            Product model = db.products.Find(id);
            return View("Create", model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            db.products.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = db.products.Find(id);
            if (product != null)
            {
                db.products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
