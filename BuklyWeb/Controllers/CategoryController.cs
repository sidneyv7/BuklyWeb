using Bukly7.Bukly.DataAcess.Data;
using BuklyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bukly7.Bukly.Models;

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

    public ActionResult Edit(int? id)
    {
      if (id == null || id == 0)
      {
        return RedirectToAction("Error", "Home");
      }

      Category? obj = _context.Categories.FirstOrDefault(s => s.Id == id);
      if (obj == null)
      {
        return RedirectToAction("Error", "Home");
      }

      return View(obj);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
      if (ModelState.IsValid)
      {
        _context.Categories.Update(obj);
        _context.SaveChanges();
        TempData["success"] = "Category Updated successfully";


        return RedirectToAction("Index");
      }
      return View();
    }

    public ActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return RedirectToAction("Error", "Home");
      }

      Category? obj = _context.Categories.FirstOrDefault(s => s.Id == id);
      if (obj == null)
      {
        return RedirectToAction("Error", "Home");
      }

      return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(Category obj)
    {
      if (ModelState.IsValid)
      {
        _context.Categories.Remove(obj);
        _context.SaveChanges();
        TempData["success"] = "Category deleted successfully";

        return RedirectToAction("Index");
      }
      return View();
    }
  }
}
