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

   public async Task<bool> ValidateUser(string email, string password)
   {
      var user = await _userRepository.GetUserByEmail(email);
      if (user == null || user.Password != password)
      {
         return false;
      }
      return true;
   }

   public Task<User?> GetUserByEmail(string email)
   {
      return _userRepository.GetUserByEmail(email);
   }
   public void RegisterUser(User userRegistration)
   {
      var user = new User
      {
         FirstName = userRegistration.FirstName,
         LastName = userRegistration.LastName,
         Email = userRegistration.Email,
         Password = userRegistration.Password
      };
      _userRepository.RegisterUser(user);
   }

   public void UpdateUser(string email, User updateUser)
   {
      var updatedUser = new User
      {
         FirstName = updateUser.FirstName,
         LastName = updateUser.LastName,
         Email = updateUser.Email,
         Password = updateUser.Password
      };
      _userRepository.UpdateUser(email, updatedUser);
   }

   public void DeleteUser(User user)
   {
      _userRepository.DeleteUser(user);
   }

   bool IUserService.ValidateUser(string email, string password)
   {
      throw new NotImplementedException();
   }

   User IUserService.GetUserByEmail(string email)
   {
      var user = _userRepository.GetUserByEmail(email);
      return user.Result;
   }
}