namespace Repositories;

using Entities;
public class RegisterRepository : IRegisterRepository
{
   public IEnumerable<User> GetAllUsers()
   {
      return JSONRegisterationManager.LoadUsers();
   }

   public void RegisterUser(User user)
   {
      var users = GetAllUsers().ToList();
      var index = users.FindIndex(u => u.Email == email);
      if (index != -1)
      {
         users.Add(user);
         JSONRegisterationManager.SaveUsers(users);
      }
   }

   public void UpdateUser(string email, User updatedUser)
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