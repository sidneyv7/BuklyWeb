using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuklyWeb.Areas.Admin.Controllers
{
  [Area("Admin")]

  public class ProductController : Controller
  {

            private readonly IUnitofWork? _unitofwork;

        public ProductController(IUnitofWork unitofWork)
        {
      _unitofwork = unitofWork;

    }
    public IActionResult Index()
    {
      return View(_unitofwork.product.GetAll());
    }



    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Create(Product obj)
    {
  

      if (ModelState.IsValid)
      {
        _unitofwork.product.Add(obj);
        _unitofwork.save();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index");
      }
      return View();

    }

  }
}
