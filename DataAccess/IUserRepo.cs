using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;

namespace DataAccess;


public interface IUserRepo
{
    public List<User> GetAllUsers();
    public User GetUserById(int userID);
    public User GetUserByName(string username, bool registering);
    public User CreateUser(User user);
    public User ResetPassword(User user);
}
