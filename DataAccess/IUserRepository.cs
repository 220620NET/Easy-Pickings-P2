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
        public List<Users> GetAllUsers();
        public Users GetUserById(int userID);
        public Users GetUserByName(string userName);
        public Users GetUserByEmail(string email);
        public Users CreateUser(Users user);
        public void ResetPassword(Users user);
    }
}
