namespace Repositories;

using MongoDB.Driver;
using MongoDB.Bson;
using Entities;
using System.Collections.Generic;
public class UserRepository : IUserRepository
{
   private readonly IMongoCollection<User> _collection;
   public IAsyncEnmerable<User> GetAllUsers()
   {
      return await _collection.ToListAsync();
   }
   public UserRepository(IMongoDatabase database)
   {
      _collection = database.GetCollection<User>("training");
   }
   public User? GetUserByEmail(string email)
   {
      return GetAllUsers().FirstOrDefault(u => u.Email == email);
   }
}