using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DataAccess.Data.Repository.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Book book= new Book();
            if (id == null)
            {
                return View(book);
            }

            book= _unitOfWork.Book.Get(id.GetValueOrDefault());

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _unitOfWork.Book.Add(book);
                }
                else
                {
                    _unitOfWork.Book.Update(book);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Book.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Book.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Book.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion
    }
}
