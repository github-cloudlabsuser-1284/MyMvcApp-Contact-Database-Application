using MyMvcApp.Models;
namespace MyMvcApp.Data;

public class UserService : IUserService
    {
        private static List<User> users = new List<User>();
        private int currentId = 0;

        public User AddUser(User user)
        {
            user.Id = ++currentId;
            users.Add(user);
            return user;
        }

        public User UpdateUser(User updatedUser)
        {
            var user = users.Find(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                // Update other properties as needed
                return user;
            }
            return null;
        }
        public bool DeleteUser(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user != null)
            {
                 users.Remove(user);
                 return true;
            }
            currentId = users?.Max(u => u.Id) ?? 0; 
            return false;
        }
        public List<User> GetAllUsers()
        {
            return new List<User>(users);
        }
    }