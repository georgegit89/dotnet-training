namespace Repositories;

using Entities;
using MongoDB.Driver;
using MongoDB.Bson;
public class ProductRepository : IProductRepository
{
   public IMongoCollection<User> _users;
   public ProductRepository(string connectionString, string databaseName, string collectionName)
   {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _users = database.GetCollection<User>(collectionName);
   }
   public IEnumerable<Product> GetAllProducts()
   {
      return JSONCatakogueManager.LoadProducts();
   }

   public Product? GetProductById(int id)
   {
      List<Product> products = GetAllProducts().ToList();
      return products.FirstOrDefault(p => p.Id == id);
   }

   public void AddProduct(Product product)
   {
      List<Product> products = GetAllProducts().ToList();
      products.Add(product);
      JSONCatakogueManager.SaveProducts(products);
   }

   public void UpdateProduct(int id, Product updatedProduct)
   {
      var _products = GetAllProducts().ToList();
      var index = _products.FindIndex(p => p.Id == id);
      if (index != -1)
      {
         _products[index] = updatedProduct;
         JSONCatakogueManager.SaveProducts(_products);
      }
   }

   public void DeleteProduct(int id)
   {
      var _products = GetAllProducts().ToList();
      var product = _products.FirstOrDefault(p => p.Id == id);
      if (product != null)
      {
         _products.Remove(product);
         JSONCatakogueManager.SaveProducts(_products);
      }
   }
}
