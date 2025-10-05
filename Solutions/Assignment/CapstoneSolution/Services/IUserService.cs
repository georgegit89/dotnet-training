namespace Services;
using Entities;
public interface IUserService
{
   bool ValidateUser(string email, string password);
   User GetUserByEmail(string email);
   void RegisterUser(User user);
   void UpdateUser(string email, User updatedUser);
   void DeleteUser(User user);
}