using Microsoft.AspNetCore.Mvc;
using Bukly7.Bukly.Models;
using Bukly.DataAcess.Repository.IRepository;

namespace BuklyWeb.Areas.Admin.Controllers
{
  [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitofWork _unitofwork;

        public CategoryController(IUnitofWork unitofWork)
        {
      _unitofwork = unitofWork;

        }


        public IActionResult Index()
        {

            List<Category> objCategoryList = _unitofwork.category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
        _unitofwork.category.Add(obj);
        _unitofwork.save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitofwork.category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
        _unitofwork.category.Update(obj);
               _unitofwork.save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitofwork.category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitofwork.category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
      _unitofwork.category.Delete(obj);
      _unitofwork.save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
