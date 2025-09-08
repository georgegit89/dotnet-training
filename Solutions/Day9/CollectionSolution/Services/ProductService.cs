namespace Services;
using Repositories;
using entities;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAllProduct();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(Product product)
    {
        _productRepository.DeleteProduct(product);
    }
}
