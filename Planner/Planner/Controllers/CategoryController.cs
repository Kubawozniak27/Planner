using System.Data.Entity;
using Planner.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Name = category.Name
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }

            else
            {
                return View("Create", category);
            }
            return RedirectToAction("Index", "Category");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id != null)
            {
                var category = _context.Categories.Find(id);

                if (category == null)
                {
                    return HttpNotFound();
                }

                return View(category);
            }



            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State= EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(category);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();



            return RedirectToAction("Index");
        }

    }



}