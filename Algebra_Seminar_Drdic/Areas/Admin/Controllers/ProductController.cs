using Algebra_Seminar_Drdic.Data;
using Algebra_Seminar_Drdic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Algebra_Seminar_Drdic.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, int[] category_id, IFormFile picture)
        {
            if (category_id.Length == 0)
            {
                return RedirectToAction("Create", new { error_message = "Molimo odaberite minimalno jednu kategoriju!" });
            }

            try
            {
               
               
                    var image_name = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "-" + picture.FileName.ToLower();

                    var save_image_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image_name);

                    using (var stream = new FileStream(save_image_path, FileMode.Create))
                    {
                        picture.CopyTo(stream);
                    }
                    product.ImageName = image_name;
              

                _context.Products.Add(product);
                _context.SaveChanges();

                int productId = product.Id;

                foreach (var category in category_id)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.ProductId = productId;
                    productCategory.CategoryId = category;
                }

                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Create", new { msg = "Nevaljan unos. Pokušajte ponovo!" });
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
