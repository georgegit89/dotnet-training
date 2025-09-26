namespace Services;
using Entities;
public interface IRegisterService
{
   void RegisterUser(User User);
   void UpdateUser(string email, User updatedUser);
   void DeleteUser(string email);
}