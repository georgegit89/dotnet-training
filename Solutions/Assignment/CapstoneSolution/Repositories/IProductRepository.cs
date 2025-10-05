
namespace Repositories;
using System.Collections.Generic;
using Entities;
public interface IProductRepository
{
   
   Task<List<Product>> GetAllProducts();
   Task<Product?> GetProductById(int id);
   Task AddProduct(Product product);
   Task UpdateProduct(int id, Product updatedProduct);
   Task DeleteProduct(int id);

}