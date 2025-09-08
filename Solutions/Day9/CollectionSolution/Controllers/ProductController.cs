namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using entities;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
      [HttpGet(Name = "/api/products")]
      public IEnumerable<Product> Get()
      {
         ProductRepository _productRepository = new ProductRepository();
          return _productRepository.GetAllProduct();
      }
}