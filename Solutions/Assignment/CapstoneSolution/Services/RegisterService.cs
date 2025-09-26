namespace Services;

using Entities;
using Repositories;
public class RegisterService : IRegisterService
{
   private readonly IRegisterRepository _registerRepository;

   public RegisterService(IRegisterRepository registerRepository)
   {
      _registerRepository = registerRepository;
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
      _registerRepository.RegisterUser(user);
   }

   public void UpdateUser(string email, User updatedUserRegistration)
   {
      var updatedUser = new User
      {
         FirstName = updatedUserRegistration.FirstName,
         LastName = updatedUserRegistration.LastName,
         Email = updatedUserRegistration.Email,
         Password = updatedUserRegistration.Password
      };
      _registerRepository.UpdateUser(email, updatedUser);
   }

   public void DeleteUser(string email)
   {
      _registerRepository.DeleteUser(email);
   }
}