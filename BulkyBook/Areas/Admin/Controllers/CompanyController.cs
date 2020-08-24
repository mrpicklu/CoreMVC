using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Company company = new Company();
            if(id==null)
            {
                //this is for create
                return View(company);
            }
            //this is for edit
            company = _unitOfWork.Comapany.Get(id.GetValueOrDefault());

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Comapany.Add(company);

                }
                else
                {
                    _unitOfWork.Comapany.Update(company);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }
        #region API Calls


        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Comapany.GetAll();

            return Json(new { data = allObj });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Comapany.Get(id);
            if(objFromDb==null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Comapany.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deelete successful" });
        }

        #endregion
    }
}