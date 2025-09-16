namespace Repositories;

using System.Collections.Generic;
using Entities;

public interface IRegisterRepository
{
   void RegisterUser(UserRegistration user);
   void UpdateUser(string email, UserRegistration updatedUser);
   void DeleteUser(string email);

   
}