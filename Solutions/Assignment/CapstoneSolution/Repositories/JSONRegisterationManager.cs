using System.Text.Json;
using Entities;
namespace Repositories;
public static class JsonRegisterationManager
{
   private static string GetJsonFilePath() => Path.Combine(Directory.GetCurrentDirectory(), "../Repositories/users.json");

   public static List<User> LoadUsers()
   {
      if (!File.Exists(GetJsonFilePath()))
      {
         return new List<User>();
      }
      var json = File.ReadAllText(GetJsonFilePath());
      return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
   }

   public static void SaveUsers(List<User> users)
   {
      var json = JsonSerializer.Serialize(users);
      File.WriteAllText(GetJsonFilePath(), json);
      
   }
}