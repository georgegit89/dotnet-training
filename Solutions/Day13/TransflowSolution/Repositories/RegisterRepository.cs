namespace Repositories;

using Entities;
public class RegisterRepository : IRegisterRepository
{
   public IEnumerable<UserRegistration> GetAllUsers()
   {
      return JSONRegisterationManager.LoadUsers();
   }

   public void RegisterUser(UserRegistration user)
   {
      var users = GetAllUsers().ToList();
      users.Add(user);
      JSONRegisterationManager.SaveUsers(users);
   }

   public void UpdateUser(string email, UserRegistration updatedUser)
   {
      var users = GetAllUsers().ToList();
      var index = users.FindIndex(u => u.Email == email);
      if (index != -1)
      {
         users[index] = updatedUser;
      }
   }
   public void DeleteUser(string email)
   {
      var users = GetAllUsers().ToList();
      var user = users.FirstOrDefault(u => u.Email == email);
      if (user != null)
      {
         users.Remove(user);
      }
   }
}