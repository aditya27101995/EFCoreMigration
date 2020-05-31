using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: CategoryController
        public ActionResult Index()
        {
            var data = db.categories.ToList();
            return View(data);
        }

       
        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            db.categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = db.categories.Find(id);
            return View("Create", category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            db.categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = db.categories.Find(id);
            if(category != null)
            {
                db.categories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
