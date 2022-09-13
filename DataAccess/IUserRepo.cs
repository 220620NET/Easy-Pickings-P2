using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;

namespace DataAccess;


public interface IUserRepo
{
    List<User> GetAllUsers();
    User GetUserById(int userID);
    User GetUserByName(string username, bool registering);
    User CreateUser(User user);
    User ResetPassword(User user);
    bool DeleteUser(int userID);
}
