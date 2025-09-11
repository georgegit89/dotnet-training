
namespace Repositories;
using System.Collections.Generic;
using Entities;
public interface IProductRepository
{
   IEnumerable<Product> GetAllProducts();
   Product? GetProductById(int id);
   void AddProduct(Product product);
   void UpdateProduct(int id, Product updatedProduct);
   void DeleteProduct(int id);
}