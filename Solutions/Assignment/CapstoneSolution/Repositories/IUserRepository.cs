namespace Repositories;

using System.Collections.Generic;
using Entities;

public interface IUserRepository
{
   Task<IEnumerable<User>> GetAllUsers();
   Task<User> GetUserByEmail(string email);
   Task AddUser(User user);
   Task UpdateUser(string email, User user);
   Task DeleteUser(User user);
   Task RegisterUser(User user);
   
}