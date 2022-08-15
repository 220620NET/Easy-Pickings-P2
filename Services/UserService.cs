using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;
using DataAccess;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepo _user;
        public UserService(IUserRepo user)
        {
            _user = user;
        }
        public List<User> GetAllUsers()
        {
            return _user.GetAllUsers();
            throw new NotImplementedException();
        }
        public User GetUserById(int userID)
        {
            return _user.GetUserById(userID);
            throw new NotImplementedException();
        }
        public User GetUserByName(string username)
        {
            return _user.GetUserByName(username,false);
            throw new NotImplementedException();
        }
        public User ResetPassword(User user)
        {
            return _user.ResetPassword(user);
            throw new NotImplementedException();
        }
        public User DeleteUser(int userID)
        {
            User user = GetUserById(userID);
            _user.DeleteUser(userID);
            return user;
        }

    }
}
