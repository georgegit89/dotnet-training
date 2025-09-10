
namespace Repositories;

using Entities;
using System.Collections.Generic;
public interface IProductRepository
{

    IEnumerable<Product> GetAllProducts();
    Product AddProduct(Product product);
    Product GetProductById(int id);
    // void AddProduct(Product product);
    bool UpdateProduct(int id, Product prod);
    bool DeleteProduct(int id);
}