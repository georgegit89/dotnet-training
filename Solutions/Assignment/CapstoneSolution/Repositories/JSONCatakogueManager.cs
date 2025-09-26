using System.Text.Json;
using Entities;
public static class JSONCatakogueManager
{
   private static string GetJsonFilePath() => Path.Combine(Directory.GetCurrentDirectory(), "../Repositories/catalog.json");
   public static IEnumerable<Product> LoadProducts()
   {
      Console.WriteLine("current directory: " + Directory.GetCurrentDirectory());
      if (!File.Exists(GetJsonFilePath()))
      {
         Console.WriteLine("Catalog file not found. Returning empty product list.");
         return Enumerable.Empty<Product>();
      }

      var json = File.ReadAllText(GetJsonFilePath());
      return JsonSerializer.Deserialize<IEnumerable<Product>>(json) ?? Enumerable.Empty<Product>();
   }

   public static void SaveProducts(IEnumerable<Product> products)
   {
      var json = JsonSerializer.Serialize(products);
      File.WriteAllText(GetJsonFilePath(), json);
   }
}
