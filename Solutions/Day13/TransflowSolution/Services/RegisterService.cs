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

   public void RegisterUser(UserRegistration userRegistration)
   {
      var user = new UserRegistration
      {
         FirstName = userRegistration.FirstName,
         LastName = userRegistration.LastName,
         Email = userRegistration.Email,
         Password = userRegistration.Password
      };
      _registerRepository.RegisterUser(user);
   }

   public void UpdateUser(string email, UserRegistration updatedUserRegistration)
   {
      var updatedUser = new UserRegistration
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