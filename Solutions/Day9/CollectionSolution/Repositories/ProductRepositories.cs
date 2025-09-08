//create respository to read products from json file
using System.Text.Json;
using entities;
using Repositories;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public ProductRepository()
    {
        // Load products from JSON file
        LoadProducts();
    }

    private void LoadProducts()
    {
        var json = File.ReadAllText("mockdata/products.json");
        _products = JsonSerializer.Deserialize<List<Product>>(json);
    }

    public IEnumerable<Product> GetAllProduct()
    {
        return _products;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var selectedProduct = GetProductById(product.Id);
        if (selectedProduct != null)
        {
            selectedProduct.Title = product.Title;
            selectedProduct.Description = product.Description;
            selectedProduct.Price = product.Price;
        }
    }

    public void DeleteProduct(Product product)
    {
        var selectedProduct = GetProductById(product.Id);
        if (selectedProduct != null)
        {
            _products.Remove(product);
        }
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}