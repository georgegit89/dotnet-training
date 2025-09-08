namespace Repositories;
using entities;

    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
