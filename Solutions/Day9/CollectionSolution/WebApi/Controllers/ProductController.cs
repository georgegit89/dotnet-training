using Repositories;
using Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);
        return productService.GetAllProducts();
    }

    [HttpPost]
    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);
        if (product == null)
            return BadRequest("Product cannot be null");

        try
        {
            var createdProduct = productService.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);
        var deleted = productService.DeleteProduct(id);
        Console.WriteLine("Deleted Data" + deleted);
        if (!deleted)
            return NotFound($"Product with Id {id} not found");

        return NoContent();
    }

    [HttpGet("{id}")]

    public IActionResult GetProductById(int id)
    {
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);
        var product = productService.GetProductById(id);
        if (product == null)
            return NotFound($"Product with given id {id} is not available");

        return Ok(product);
    }

    [HttpPut("{id}")]

    public ActionResult<Product> UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        IProductRepository productRepository = new ProductRepository();
        IProductService productService = new ProductService(productRepository);
        var product = productService.UpdateProduct(id, updatedProduct);

        if (updatedProduct == null || id != updatedProduct.Id)
            return BadRequest("Product Id mismatch or invalid data");


    if (!product)
        return NotFound($"Product with Id {id} not found");

    return Ok($"Product with Id {id} updated successfully");
        
    }
   
}