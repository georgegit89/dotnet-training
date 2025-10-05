namespace Repositories;

using MongoDB.Driver;
using MongoDB.Bson;
using Entities;
using System.Collections.Generic;
public class UserRepository : IUserRepository
{
public readonly IMongoCollection<User> _users;
   public UserRepository(string connectionString, string databaseName)
   {
      var client = new MongoClient(connectionString);
      var database = client.GetDatabase(databaseName);
      _users = database.GetCollection<User>("User");
   }
   public async Task<IEnumerable<User>> GetAllUsers() =>
      await _users.Find(_ => true).ToListAsync();

   public async Task<User> GetUserByEmail(string email) => 
      await _users.Find(user => user.Email == email).FirstOrDefaultAsync();
   
   public async Task AddUser(User user) =>
      await _users.InsertOneAsync(user);

   public async Task UpdateUser(User user) =>
     await _users.ReplaceOneAsync(u => u.Email == user.Email, user);

   public async Task DeleteUser(User user) =>
      await _users.DeleteOneAsync(u => u.Email == user.Email);

   public Task UpdateUser(string email, User user)
   {
      throw new NotImplementedException();
   }

   public Task RegisterUser(User user)
   {
      throw new NotImplementedException();
   }
}