namespace Repositories;

using MongoDB.Driver;
using MongoDB.Bson;
using Entities;
using System.Collections.Generic;
public class UserRepository : IUserRepository
{
   public IMongoCollection<User> _users;
   public IEnumerable<User> GetAllUsers()
   {
      return JsonRegisterationManager.LoadUsers();
   }
   public UserRepository(string connectionString, string databaseName, string collectionName)
   {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _users = database.GetCollection<User>(collectionName);
   }
   public User? GetUserByEmail(string email)
   {
      return GetAllUsers().FirstOrDefault(u => u.Email == email);
   }
}