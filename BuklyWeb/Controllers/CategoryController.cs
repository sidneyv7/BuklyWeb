using BuklyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuklyWeb.Controllers
{
  public class CategoryController : Controller
  {
    private readonly BulkyContext _context;

        public CategoryController(BulkyContext context)
        {
      _context = context;            

        }
        public IActionResult Index()
    {

      return View(_context.Categories.ToList());

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
        _context.Categories.Add(obj);
        _context.SaveChanges();
        TempData["success"] = "Category Created successfully";

        return RedirectToAction("Index");
      }
      return View();
    }

  }
}
