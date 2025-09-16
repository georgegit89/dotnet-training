namespace Services;
using Entities;
public interface IRegisterService
{
   void RegisterUser(UserRegistration userRegistration);
   void UpdateUser(string email, UserRegistration updatedUserRegistration);
   void DeleteUser(string email);
}