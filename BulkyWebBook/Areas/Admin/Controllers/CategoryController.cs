using BulkyWebBook.DataAccess.Data;
using BulkyWebBook.DataAccess.Repository.IRepository;
using BulkyWebBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IcategoryRepository _categoryRepo;
        public CategoryController(IcategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepo.GetAll().ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.save();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Edit(int? CategoryID)
        {
            if (CategoryID == null || CategoryID == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _categoryRepo.Get(u => u.CategoryId == CategoryID);
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
                _categoryRepo.update(obj);
                _categoryRepo.save();
                TempData["Success"] = "Category Updated Successfully.";

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
            Category CategoryFromDb = _categoryRepo.Get(u => u.CategoryId == CategoryID);
            //Category CategoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.CategoryId==CategoryID);
            //Category CategoryFromDb2= _db.Categories.Where(u=>u.CategoryId==CategoryID).FirstOrDefault();   

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? CategoryId)
        {
            Category categoryobj = _categoryRepo.Get(u => u.CategoryId == CategoryId); ;
            if (categoryobj == null) { return NotFound(); }
            _categoryRepo.Remove(categoryobj);
            _categoryRepo.save();
            TempData["Success"] = "Category Updated Successfully.";

            return RedirectToAction("Index", "Category");
        }
    }
}

