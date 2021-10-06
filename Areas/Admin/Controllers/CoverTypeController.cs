using System.Reflection.Metadata;
using Dapper;
using LaptopStore.DataAccess.Repository.IRepository;
using LaptopStore.Models;
using LaptopStore.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null)
            {
                return View(coverType);
            }

            // coverType = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);
            // if (coverType == null)
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     return View(coverType);
            // }
            var parameter = new DynamicParameters();
            parameter.Add("@Id",id);
            coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_GetAll, parameter);
            if (coverType == null)
            {
                return NotFound();
            }
            else
            {
                return View(coverType);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                // if (coverType.Id == 0)
                // {
                //     _unitOfWork.CoverType.Add(coverType);
                // }
                // else
                // {
                //     _unitOfWork.CoverType.Update(coverType);
                // }
                // _unitOfWork.Save();
                // return RedirectToAction(nameof(Index));
                var parameter = new DynamicParameters();
                 parameter.Add("@Name",coverType.Name);
                 if (coverType.Id == 0)
                 {
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Create, parameter);
                 }
                 else
                 {
                     _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Update,parameter);
                 }
                 _unitOfWork.Save();
                 return RedirectToAction(nameof(Index));
            }

            return View(coverType);
        }

        #region API_Calls

        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.CoverType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(o => o.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "fail while deleting" });
            }
            else
            {
                _unitOfWork.CoverType.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "deleted successfully" });
            }
        }
        #endregion
    }
}