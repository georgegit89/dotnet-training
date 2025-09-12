using Services;
using Entities;
public class ProductController : Controller
{
   private readonly IProductService _productService;

   public ProductController(IProductService productService)
   {
      _productService = productService;
   }

   public IActionResult Index()
   {
      var products = _productService.GetAllProducts();
      return View(products);
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
      _productService.UpdateProduct(product);
      return RedirectToAction("Index");
   }

   [HttpPost]
   public IActionResult Delete(int id)
   {
      _productService.DeleteProduct(id);
      return RedirectToAction("Index");
   }
}
