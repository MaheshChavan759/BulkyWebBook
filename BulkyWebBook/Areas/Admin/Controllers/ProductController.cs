using BulkyWebBook.DataAccess.Data;
using BulkyWebBook.DataAccess.Repository.IRepository;
using BulkyWebBook.Models;
using BulkyWebBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace BulkyWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> ProductList = _unitOfWork.Product.GetAll().ToList();
           
            
            return View(ProductList);
        }
        public IActionResult Upsert(int? Id)
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

            if (Id == null || Id == 0)
            {
                //Create functionality 
                return View(productVM);
            }
            else
            {
                // For Update 
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == Id);
                return View(productVM);
            }



           
           
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwroot = _webHostEnvironment.WebRootPath;

                if (file != null) 
                {   
                    string filename  = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string ProductPath = Path.Combine(wwwroot, @"images\product");

                    if(!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //Delete the old Image
                        var oldimage = Path.Combine(wwwroot,obj.Product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldimage)) 
                        {
                            System.IO.File.Delete(oldimage);
                        
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(ProductPath, filename), FileMode.Create)) 
                    {
                        file.CopyTo(filestream);
                    }

                    obj.Product.ImageUrl = @"\images\product\" + filename;
                
                }


                if(obj.Product.Id==0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }

                else
                {
                    _unitOfWork.Product.update(obj.Product);
                }
                
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
            TempData["Success"] = "Product Deleted Successfully.";

            return RedirectToAction("Index", "Product");
        }
    }
}

