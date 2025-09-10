namespace Services;
using Entities;
public interface IProductService
{
   IEnumerable<Product> GetAllProducts();
   Product AddProduct(Product product);
   Product GetProductById(int id);
   bool UpdateProduct(int id, Product prod);
   bool DeleteProduct(int id);
}