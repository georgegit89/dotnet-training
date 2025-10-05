namespace Services;
using Entities;

public interface IProductService
{
   Task<List<Product>> GetAllAsync();
   Task<Product?> GetByIdAsync(string id);
   Task CreateAsync(Product product);
   Task UpdateAsync(string id, Product product);
   Task DeleteAsync(string id);
}
