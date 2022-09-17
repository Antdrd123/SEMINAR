using Algebra_Seminar_Drdic.Data;
using Algebra_Seminar_Drdic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Algebra_Seminar_Drdic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //kaj je ovaj logger
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product(int categoryId)
        {
            ViewBag.Categories = _context.Categories.ToList();

            if(categoryId != 0)
            {
                //NEKUZIM
                List<Product> products = _context.Products.Where(p => _context.ProductCategories.Where(pc => pc.CategoryId == categoryId).Select(pc => pc.ProductId).ToList().Contains(p.Id)).ToList();
                return View(products);
            }
            else
            {
               var products2 = _context.Products.ToList();
                return View(products2);
            }
            
        }

        public IActionResult Details(int id)
        {
            var categories = _context.ProductCategories.Where(c => c.ProductId == id).Select(c => c.Category.Title).ToList();
            ViewBag.CategoryDetails = categories;

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return View(product);


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}