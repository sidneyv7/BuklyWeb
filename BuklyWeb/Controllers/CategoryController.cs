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



  }
}
