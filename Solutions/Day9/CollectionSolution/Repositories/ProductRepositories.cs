namespace Repositories;
using System.Collections.Generic;
using Entities;
using System.Collections.Generic;

using System.Text.Json;
using System.IO;
//CRUD Operations agains List Colllection
public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>();
    string path = @"C:\CodeBase-Nihilent\MyDotnetTraining\NihilentDotNetTraining\Solutions\Day9\ECommerceSolution\products.json";
    public ProductRepository()
    {

    }
    public IEnumerable<Product> GetAllProducts()
    {
        

        string jsonStringFromFile = File.ReadAllText(path);
        // Console.WriteLine("File Data New APP" + jsonStringFromFile);
        List<Product>? productsFromFile = JsonSerializer.Deserialize<List<Product>>(jsonStringFromFile);
        return productsFromFile;

    }

    //   public static void SaveAllProducts(List<Product> products)
    //     {
    //         var jsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
    //         File.WriteAllText(filePath, jsonData);
    //     }

    public Product GetProductById(int id)
    {
        return GetAllProducts().FirstOrDefault(p => p.Id == id);
    }

   public Product AddProduct(Product product)
    {
      var products = GetAllProducts().ToList();
        product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
        products.Add(product);
        product.Id = _products.Count + 1; // Simulate DB auto-increment
        _products.Add(product);
        Console.WriteLine("Add" + products);
        var jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, jsonString);
        return product;
    }

    public bool UpdateProduct(int id, Product updatedProduct)
{
    var products = GetAllProducts(); // read JSON file
    var existingProduct = products.FirstOrDefault(p => p.Id == id);

    if (existingProduct == null)
        return false;

    // Update fields
    existingProduct.Title = updatedProduct.Title;
    existingProduct.Price = updatedProduct.Price;
    existingProduct.Description = updatedProduct.Description;

    // Write back to file
    var jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(path, jsonString);

    return true;
}

    public bool DeleteProduct(int id)
    {

        var products = GetAllProducts().ToList();
        Console.WriteLine("Delete" + products);
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return false;
        }

        products.Remove(product);
        var jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, jsonString);
        return true;       
    }
}