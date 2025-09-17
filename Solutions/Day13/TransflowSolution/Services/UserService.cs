namespace Services;

using Entities;
using Repositories;
public class UserService : IUserService
{
   private readonly IUserRepository _userRepository;

   public UserService(IUserRepository userRepository)
   {
      _userRepository = userRepository;
   }

   public bool ValidateUser(string email, string password)
   {
      var user = _userRepository.GetUserByEmail(email);
      if (user == null || user.Password != password)
      {
         return false;
      }
      return true;
   }

   public User GetUserByEmail(string email)
   {
      return _userRepository.GetUserByEmail(email);
   }
}