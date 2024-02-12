using BulkyWebBook.DataAccess.Data;
using BulkyWebBook.DataAccess.Repository.IRepository;
using BulkyWebBook.Models;
using BulkyWebBook.Models.ViewModels;
using BulkyWebBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace BulkyWebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
  
        public CompanyController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            
        }
        public IActionResult Index()
        {
            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(CompanyList);
        }
        public IActionResult Upsert(int? id)
        {
            

            if (id == null || id == 0)
            {
                //Create functionality 
                return View(new Company());
            }
            else
            {
                // For Update 

                //Company p = _unitOfWork.Company.Get(u => u.Id == id);
                List<Company> prods = (List<Company>)_unitOfWork.Company.GetAll();
                 Company companyobj = prods.FirstOrDefault(b => b.Id == id);
                return View(companyobj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company obj )
        {
            if (ModelState.IsValid)
            {
                if ( obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                }

                else
                {
                    _unitOfWork.Company.update(obj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company Created Successfully.";
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(obj);

            }
               
            
        }



        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return Json(new { data = objCompanyList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var CompanyToDelete = _unitOfWork.Company.Get(u => u.Id == id);

          

            _unitOfWork.Company.Remove(CompanyToDelete);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}


