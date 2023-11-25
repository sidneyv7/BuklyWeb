using Bukly.DataAcess.Repository;
using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuklyWeb.Areas.Customer.Controllers
{

  [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

    private readonly IUnitofWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitofWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;

    }

    public IActionResult Index()
        {

      IEnumerable<Product> productList = _unitOfWork.product.GetAll(includeProperties: "Category");
      return View(productList);

    }

    public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Error()
        //{
        //    return View();
        //}
    }
}
