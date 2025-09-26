namespace Services;
using Entities;
public interface IUserService
{
   bool ValidateUser(string email, string password);
   User GetUserByEmail(string email);
}