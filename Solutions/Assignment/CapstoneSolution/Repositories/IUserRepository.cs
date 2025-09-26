namespace Repositories;
using Entities;
public interface IUserRepository
{
   User? GetUserByEmail(string email);
}