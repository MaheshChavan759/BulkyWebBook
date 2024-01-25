using BulkyWebBook.DataAccess.Data;
using BulkyWebBook.DataAccess.Repository.IRepository;
using BulkyWebBook.Models;
using BulkyWebBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BulkyWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public IActionResult Index()
        {
            List<Product> ProductList = _unitOfWork.Product.GetAll().ToList();
           
            
            return View(ProductList);
        }
        public IActionResult Create()
        {
            

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.category.GetAll()
               .Select(u => new SelectListItem
               {
                   Text = u.CategoryName,
                   Value = u.CategoryId.ToString()

               }),
                Product = new Product()

            };
           
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully.";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                obj.CategoryList = _unitOfWork.category.GetAll()
             .Select(u => new SelectListItem
             {
                 Text = u.CategoryName,
                 Value = u.CategoryId.ToString()
             });
                return View(obj);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product CategoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.CategoryId==CategoryID);
            //Product CategoryFromDb2= _db.Categories.Where(u=>u.CategoryId==CategoryID).FirstOrDefault();   

            if (ProductFromDb == null)
            {
                return NotFound();
            }


            return View(ProductFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Product Updated Successfully.";

                return RedirectToAction("Index", "Product");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productDelFromDB = _unitOfWork.Product.Get(u => u.Id == id);
            //Product CategoryFromDb1 = _db.Categories.FirstOrDefault(u=> u.CategoryId==CategoryID);
            //Product CategoryFromDb2= _db.Categories.Where(u=>u.CategoryId==CategoryID).FirstOrDefault();   

            if(productDelFromDB == null)
            {
                return NotFound();
            }
            return View(productDelFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product ProductcfromDB = _unitOfWork.Product.Get(u => u.Id == id); ;
            if (ProductcfromDB == null) { return NotFound(); }
            _unitOfWork.Product.Remove(ProductcfromDB);
            _unitOfWork.Save();
            TempData["Success"] = "Product Updated Successfully.";

            return RedirectToAction("Index", "Product");
        }
    }
}

