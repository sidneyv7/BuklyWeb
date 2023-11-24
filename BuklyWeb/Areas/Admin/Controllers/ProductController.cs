using Bukly.DataAcess.Repository;
using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.Models;
using Bukly7.Bukly.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      List<Product> objProductList = _unitofwork.product.GetAll().ToList();
      return View(objProductList);
    }



    public IActionResult Upsert(int? id)
    {
      ProductVM productVM = new()
      {
        CategoryList = _unitofwork.category.GetAll().Select(u => new SelectListItem
        {
          Text = u.Name,
          Value = u.Id.ToString()
        }),
        Product = new Product()
      };
      if (id == null || id == 0)
      {
        //create
        return View(productVM);
      }
      else
      {
        //update
        productVM.Product = _unitofwork.product.Get(u => u.Id == id);
        return View(productVM);
      }

    }

    [HttpPost]
    public IActionResult Upsert(ProductVM productVM, IFormFile? file)
    {
      if (ModelState.IsValid)
      {
        _unitofwork.product.Add(productVM.Product);
        _unitofwork.save();
        TempData["success"] = "Product created successfully";
        return RedirectToAction("Index");
      }
      else
      {
        productVM.CategoryList = _unitofwork.category.GetAll().Select(u => new SelectListItem
        {
          Text = u.Name,
          Value = u.Id.ToString()
        });
        return View(productVM);
      }
    }



    public IActionResult Create()
    {
      ProductVM productVM = new()
      {
        CategoryList = _unitofwork.category
   .GetAll().Select(u => new SelectListItem
   {
     Text = u.Name,
     Value = u.Id.ToString()
   }),
        Product = new Product()
      };

      return View(productVM);
    }
    [HttpPost]
    public IActionResult Create(ProductVM productVM)  
    {
  

      if (ModelState.IsValid)
      {
        _unitofwork.product.Add(productVM.Product);
        _unitofwork.save();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index");
      }
      else
      {
        productVM.CategoryList = _unitofwork.category.GetAll().Select(u => new SelectListItem
        {
          Text = u.Name,
          Value = u.Id.ToString()
        });
        return View(productVM);
      }

    }
    public IActionResult Edit(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      Product? productFromDb = _unitofwork.product.Get(u => u.Id == id);
      //Product? productFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
      //Product? productFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

      if (productFromDb == null)
      {
        return NotFound();
      }
      return View(productFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Product obj)
    {
      if (ModelState.IsValid)
      {
        _unitofwork.product.Update(obj);
        _unitofwork.save();
        TempData["success"] = "Product updated successfully";
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
      Product? productFromDb = _unitofwork.product.Get(u => u.Id == id);

      if (productFromDb == null)
      {
        return NotFound();
      }
      return View(productFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
      Product? obj = _unitofwork.product.Get(u => u.Id == id);
      if (obj == null)
      {
        return NotFound();
      }
      _unitofwork.product.Delete(obj);
      _unitofwork.save();
      TempData["success"] = "Product deleted successfully";
      return RedirectToAction("Index");
    }
  }
}
