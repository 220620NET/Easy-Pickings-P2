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
        private readonly IUserRepo _contact;
        public UserService(IUserRepo contact)
        {
            _contact = contact;
        }
        public List<User> GetAllUsers()
        {
            return _contact.GetAllUsers();
            throw new NotImplementedException();
        }
        public User GetUserById(int userID)
        {
            return _contact.GetUserById(userID);
            throw new NotImplementedException();
        }
        public User GetUserByName(string username)
        {
            return _contact.GetUserByName(username,false);
            throw new NotImplementedException();
        }
       /* public User CreateUser(User user)
        {
            return _contact.CreateUser(user);
        } AuthService */
        public User ResetPassword(User user)
        {
            return _contact.ResetPassword(user);
            throw new NotImplementedException();
        }

    }
}
