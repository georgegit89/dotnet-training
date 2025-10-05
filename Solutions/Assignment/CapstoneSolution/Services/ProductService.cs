namespace Services;
using Entities;
using Repositories;
using System.Collections.Generic;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Product>> GetAllAsync() => _repo.GetAllProducts();
    public Task<Product?> GetByIdAsync(int id) => _repo.GetProductById(id);
    public Task CreateAsync(Product product) => _repo.AddProduct(product);
    public Task UpdateAsync(int id, Product product) => _repo.UpdateProduct(id, product);
    public Task DeleteAsync(int id) => _repo.DeleteProduct(id);
}