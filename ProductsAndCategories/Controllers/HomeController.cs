using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProductsAndCategories.Models;
using ProductsAndCategories.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        //----------------------------------- I N D E X -------------------------
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Product> allProducts = _context.Products.ToList();
            ViewBag.Products = allProducts;

            return View();
        }
        //----------------------------------- A D D   N E W   P R O D U C T  -------------------------
        [HttpPost]
        [Route("NewProduct")]
        public IActionResult NewProduct(ProductViewModel product)
        {
            Product NewProduct = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = (int) product.Price
            };
            _context.Products.Add(NewProduct);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        //----------------------------------- C A T E G O R Y   P A G E -------------------------
        [HttpGet]
        [Route("categories")]
        public IActionResult Categories()
        {
            List<Category> allCategories = _context.Categories.ToList();
            ViewBag.Categories = allCategories;

            return View();
        }
        //----------------------------------- A D D   N E W   C A T E G O R Y  -------------------------
        [HttpPost]
        [Route("NewCategory")]
        public IActionResult NewCategory(CategoryViewModel category)
        {

            Category NewCategory = new Category
            {
                CategoryName = category.CategoryName
            };
            _context.Categories.Add(NewCategory);
            _context.SaveChanges();
            
            return RedirectToAction("AddCategory");
        }
        //----------------------------------- G O   T O   P R O D U C T   P A G E -------------------------
        [HttpGet]
        [Route("products/{product_id}")]
        public IActionResult Product(int product_id)
        {
            Product RetrievedProduct=_context.Products.FirstOrDefault(p=> p.ProductID == product_id);
            ViewBag.Product = RetrievedProduct;
            
            List<Category> allCategories = _context.Categories.ToList();
            ViewBag.Categories = allCategories;

            return View("Product");
        }
        //----------------------------------- A D D   A S S O C I A T I O N -------------------------
        [HttpPost]
        [Route("products/{product_id}")]
        public IActionResult AddAssociation(int product_id, int category_id)
        {
            Category categoryToJoin = _context.Categories.FirstOrDefault(c=> c.CategoryID == category_id);

            Product productToJoin = _context.Products.Include(a=>a.CategorizedProducts).FirstOrDefault(p=>p.ProductID == product_id);

            // Product RetrievedProduct=_context.Products.FirstOrDefault(p=> p.ProductID == product_id);
            // ViewBag.Product = RetrievedProduct;

            // List<Category> allCategories = _context.Categories.ToList();
            // ViewBag.Categories = allCategories;
            
            // var productwithcatandass = _context.Products.Include(p=>p.CategorizedProducts).ThenInclude(c=>c.CategoryToJoin).ToList();

            // var personWithSubsAndMags = dbContext.Persons
            // .Include(person => person.Subscriptions)
            // .ThenInclude(sub => sub.Magazine)
            // .ToList();
            Association newAssociation = new Association
            {
                ProductID = product_id,
                CategoryID = category_id,
                ProductToJoin = productToJoin,
                CategoryToJoin = categoryToJoin
            };
            return RedirectToAction("Product");
        }
        //------------------------------------------- A D D   C A T E G O R Y   T O   A   P R O D U C T -------------------------------------
        // [HttpPost]
        // [Route("AddCategoryToPoduct")]
        // public IActionResult AddCategoryToPoduct(Association association, int product_id, int category_id)
        // {

            
        //     return RedirectToAction("Product");

    }
}
