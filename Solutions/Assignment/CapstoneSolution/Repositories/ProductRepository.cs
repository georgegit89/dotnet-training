namespace Repositories;

using Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
public class ProductRepository : IProductRepository
{
   public readonly IMongoCollection<Product> _products;
   public ProductRepository(string connectionString, string databaseName)
   {
      Console.WriteLine("connection string: " + connectionString);
      Console.WriteLine("database name: " + databaseName);
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _products = database.GetCollection<Product>("products");
      Console.WriteLine("test(database);" + test(database));
   }
   public bool test(IMongoDatabase database)
   {
      try
      {
         // This command attempts to get database statistics, which requires a working connection
         var stats = database.RunCommand<BsonDocument>(new BsonDocument { { "dbstats", 1 } });
         return true; // If successful, connection is good
      }
      catch (MongoConnectionException)
      {
         return false; // Connection failed
      }
      catch (Exception)
      {
         return false; // General failure
      }
   }

   public async Task<Product> GetProductById(int id) =>
      await _products.Find(product => product.Id == id).FirstOrDefaultAsync();

   public async Task AddProduct(Product product) =>
      await _products.InsertOneAsync(product);

   public async Task UpdateProduct(int id, Product updatedProduct) =>
     await _products.ReplaceOneAsync(p => p.Id == id, updatedProduct);

   public async Task DeleteProduct(int id) =>
      await _products.DeleteOneAsync(product => product.Id == id);

   async Task<List<Product>> IProductRepository.GetAllProducts()
   {
      Console.WriteLine("Hello from GetAllProducts in ProductRepository" + _products.Find(_ => true).ToListAsync());
      return await _products.Find(_ => true).ToListAsync();
   }
}
