namespace Services;
using Entities;
public interface IRegisterService
{
   void RegisterUser(UserRegisteration userRegistration);
   void UpdateUser(string email, UserRegisteration updatedUserRegistration);
   void DeleteUser(string email);
}