namespace Repositories;

using Entities;
using MongoDB.Driver;
using MongoDB.Bson;
public class ProductRepository : IProductRepository
{
   public readonly IMongoCollection<Product> products;
   public ProductRepository(string connectionString, string databaseName, string collectionName)
   {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _products = database.GetCollection<User>(collectionName);
   }
   public async Task<IEnumerable<Product>> GetAllProducts()
   {
      await _products.Find(_ => true).ToListAsync();
   }
   public async Task<Product> GetProductById(string id)
   {
      await _products.Find(product => product.id == id).FirstOrDefaultAsync();
   }
   public async Task AddUser(Product product)
   {
      await _products.insertOneAsync(product);
   }

   public async Task UpdateProduct(int id, Product updatedProduct)
   {
     await _products.ReplaceOneAsync()
   }

   public async Task DeleteProduct(int id)
   {
      awair _products.DeleteOneAsyn(product => product.id == id);
   }
}
