namespace Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   [BsonElement("Id")]
   public string? _Id { get; set; }
   public string Id { get; set; }
   public string Name { get; set; }
   public decimal Price { get; set; }
   public string Description { get; set; }
   public string ImageUrl { get; set; }
   public bool InStock { get; set; }
}
