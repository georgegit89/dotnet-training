namespace Controllers;
using Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id) =>
        Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        await _service.CreateAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}