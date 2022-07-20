﻿using Algebra_Seminar_Drdic.Data;
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

            //List<Category> categories = _context.ProductCategories.Where(c => c.ProductId == id).Select(c )
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
                TempData["AlertMessageF"] = "Odaberite kategoriju proizvoda!";
                return RedirectToAction("Create");
            }

            try
            {
               
                    var image_name = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "-" + picture.FileName.ToLower();

                    var save_image_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", image_name);

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
                    _context.ProductCategories.Add(productCategory);
                }

                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
                return RedirectToAction("Create");
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Category> categories = _context.ProductCategories.Where(pc => pc.ProductId == id).Select(pc => pc.Category).ToList();
            ViewBag.SelectedCategories = categories;

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);

            return View(product);
        }
        
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, int[] category_id)
        {
            try
            {
                _context.Products.Update(product);

                List<ProductCategory> category = _context.ProductCategories.Where(c => c.Id == product.Id).ToList();
                _context.ProductCategories.RemoveRange(category);

                foreach (var cat in category_id)
                {

                    ProductCategory ProductCategory = new ProductCategory();
                    ProductCategory.ProductId = product.Id;
                    ProductCategory.CategoryId = cat;

                    _context.ProductCategories.Add(ProductCategory);

                }

                _context.SaveChanges();

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
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

           
            if (product == null)
            {
                return RedirectToAction("Index", new { msg = "Proizvod ne postoji!" });
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product, int[] cat_id)
        {
            try
            {
                var delete_product = _context.Products.SingleOrDefault(pr => pr.Id == product.Id);

                if (delete_product == null)
                {
                    return View("Delete", new { msg = "Unknown product!" });
                }
                _context.Products.Remove(delete_product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
