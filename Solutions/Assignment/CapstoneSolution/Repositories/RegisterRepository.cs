namespace Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using Entities;
public class RegisterRepository : IRegisterRepository
{
   public IMongoCollection<User> _users;
   public IEnumerable<User> GetAllUsers()
   {
      return JsonRegisterationManager.LoadUsers();
   }
   public RegisterRepository(string connectionString, string databaseName, string collectionName)
   {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _users = database.GetCollection<User>(collectionName);
   }
   public void RegisterUser(User user)
   {
      var users = GetAllUsers().ToList();
      var index = users.FindIndex(u => u.Email == user.Email);
      if (index != -1)
      {
         users.Add(user);
         JsonRegisterationManager.SaveUsers(users);
      }
   }

   public void UpdateUser(string email, User updatedUser)
   {
      var users = GetAllUsers().ToList();
      var index = users.FindIndex(u => u.Email == email);
      if (index != -1)
      {
         users[index] = updatedUser;
      }
   }
   public void DeleteUser(string email)
   {
      var users = GetAllUsers().ToList();
      var user = users.FirstOrDefault(u => u.Email == email);
      if (user != null)
      {
         users.Remove(user);
      }
   }
}