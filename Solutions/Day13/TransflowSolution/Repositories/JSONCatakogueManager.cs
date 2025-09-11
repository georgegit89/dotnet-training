using System.Text.Json;
using Entities;
public static class JSONCatakogueManager
{
   private static readonly string _filePath = "catalog.json";

   public static IEnumerable<Product> LoadProducts()
   {
      if (!File.Exists(_filePath))
      {
         return Enumerable.Empty<Product>();
      }

      var json = File.ReadAllText(_filePath);
      return JsonSerializer.Deserialize<IEnumerable<Product>>(json) ?? Enumerable.Empty<Product>();
   }

   public static void SaveProducts(IEnumerable<Product> products)
   {
      var json = JsonSerializer.Serialize(products);
      File.WriteAllText(_filePath, json);
   }
}
