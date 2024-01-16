using BulkyWebBook.Data;
using BulkyWebBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category obj)
        {
            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            
          return View();
        }

        public IActionResult Edit(int? CategoryID)
        {
            if( CategoryID==null ||CategoryID == 0) 
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(CategoryID);
            //Category CategoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.CategoryId==CategoryID);
            //Category CategoryFromDb2= _db.Categories.Where(u=>u.CategoryId==CategoryID).FirstOrDefault();   

            if (CategoryFromDb == null)
            {
                return NotFound();
            }


            return View(CategoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Delete(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _db.Categories.Find(CategoryID);
            //Category CategoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.CategoryId==CategoryID);
            //Category CategoryFromDb2= _db.Categories.Where(u=>u.CategoryId==CategoryID).FirstOrDefault();   

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? CategoryId)
        {
            Category categoryobj = _db.Categories.Find(CategoryId);
            if (categoryobj == null) { return NotFound(); }
            _db.Categories.Remove(categoryobj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}

