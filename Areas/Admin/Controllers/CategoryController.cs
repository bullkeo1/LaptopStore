using LaptopStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LaptopStore.Models;

namespace LaptopStore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public CategoryController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        // GET
        public IActionResult Index()
        {
            return View();


        }
[HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }

            category = _unitOfwork.Category.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfwork.Category.Add(category);
                }
                else
                {
                    _unitOfwork.Category.Update(category);
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        #region API_Call

        public IActionResult GetAll()
        {
            var allObj = _unitOfwork.Category.GetAll();
            return Json(new { data = allObj });
           
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfwork.Category.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            else
            {
                _unitOfwork.Category.Remove(obj);
                _unitOfwork.Save();
                return Json(new { success = true, message = "deleted successfully" });
            }
            
        }
        
        #endregion
    }
}