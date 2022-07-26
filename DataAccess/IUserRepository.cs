using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUserById(int userID);
        public User GetUserByName(string userName);
        public User GetUserByEmail(string email);
        public User CreateUser(User user);
        public void ResetPassword(User user);
    }
}
