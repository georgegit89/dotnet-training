namespace Repositories;

using Entities;
public class RegisterRepository : IRegisterRepository
{
   public IEnumerable<UserRegisteration> GetAllProducts()
   {
      return JSONRegisterationManager.LoadUsers();
   }

   public void RegisterUser(UserRegisteration user)
   {
      var users = JSONRegisterationManager.LoadUsers();
      users.Add(user);
      JSONRegisterationManager.SaveUsers(users);
   }

   public void UpdateUser(string email, UserRegisteration updatedUser)
   {
      var users = JSONRegisterationManager.LoadUsers();
      var index = users.FindIndex(u => u.Email == email);
      if (index != -1)
      {
         users[index] = updatedUser;
      }
   }
   public void DeleteUser(string email)
   {
      var user = users.FirstOrDefault(u => u.Email == email);
      if (user != null)
      {
         users.Remove(user);
      }
   }
}