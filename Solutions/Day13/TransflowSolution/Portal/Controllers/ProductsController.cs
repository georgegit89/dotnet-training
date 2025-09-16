using Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
namespace Portal.Controllers;

public class ProductsController : Controller
{
   private readonly IProductService _productService;

   public ProductsController(IProductService productService)
   {
      _productService = productService;
   }

   public IActionResult Index()
   {

      var products = _productService.GetAllProducts();
      Console.WriteLine("Products retrieved: " + products.Count());
      Console.WriteLine("Products retrieved: " + products);
      return View(products);// Pass the products to the view
   }

   public IActionResult Details(int id)
   {
      var product = _productService.GetProductById(id);
      if (product == null)
      {
         return NotFound();
      }
      return View(product);
   }

   [HttpPost]
   public IActionResult Create(Product product)
   {
      if (!ModelState.IsValid)
      {
         return View(product);
      }
      _productService.AddProduct(product);
      return RedirectToAction("Index");
   }

   [HttpPost]
   public IActionResult Edit(Product product)
   {
      if (!ModelState.IsValid)
      {
         return View(product);
      }
      _productService.UpdateProduct(0, product);
      return RedirectToAction("Index");
   }

   [HttpPost]
   public IActionResult Delete(int id)
   {
      _productService.DeleteProduct(id);
      return RedirectToAction("Index");
   }

}
