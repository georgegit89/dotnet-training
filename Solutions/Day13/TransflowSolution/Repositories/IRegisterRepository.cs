namespace Repositories;

using System.Collections.Generic;
using Entities;

public interface IRegisterRepository
{
   void RegisterUser(User user);
   void UpdateUser(string email, User updatedUser);
   void DeleteUser(string email);

   
}