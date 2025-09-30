namespace Entities;

public class MongoDbSettings
{
   public string ConnectionString { get; set; } = null!;
   public string DatabaseName { get; set; } = null!;
   public string CollectionName { get; set; } = null!; // Optional, if you have a default collection
}