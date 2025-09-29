namespace Repositories;
using Entities;
using System.Collections.Generic;
public class UserRepository : IUserRepository
{
   public IEnumerable<User> GetAllUsers()
   {
      return JsonRegisterationManager.LoadUsers();
   }

   public User? GetUserByEmail(string email)
   {
      return GetAllUsers().FirstOrDefault(u => u.Email == email);
   }
}