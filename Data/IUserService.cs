using MyMvcApp.Models;
namespace MyMvcApp.Data;
 public interface IUserService
    {
        User AddUser(User user);
        bool DeleteUser(int id);
        List<User> GetAllUsers();

        User UpdateUser(User updatedUser);
    }