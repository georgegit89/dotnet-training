
namespace Repositories;
using System.Collections.Generic;
using Entities;
public interface IProductRepository
{
   
   Task<List<Product>> GetAllProducts();
   Task<Product?> GetProductById(string id);
   Task AddProduct(Product product);
   Task UpdateProduct(string id, Product updatedProduct);
   Task DeleteProduct(string id);

}