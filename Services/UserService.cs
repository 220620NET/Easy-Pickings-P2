using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;
using DataAccess;
using CustomExceptions;

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
            throw new InvalidUserException();
        }
        public User GetUserById(int userID)
        {
            try
            {
                List<User> all = _user.GetAllUsers();
                bool there = true;
                foreach (User user in all)
                {
                    if (userID != user.userID)
                    {
                        there = false;
                    }
                }
                if (!there)
                {
                    throw new InvalidUserException();
                }
                return _user.GetUserById(userID);
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
        }
        public User GetUserByName(string username)
        {
            try
            {
                List<User> all = _user.GetAllUsers();
                bool there = true;
                foreach (User user in all)
                {
                    if (username != user.username)
                    {
                        there = false;
                    }
                }
                if (!there)
                {
                    throw new InvalidUserException();
                }
                return _user.GetUserByName(username, false);
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
        }

        public User DeleteUser(int userID)
        {
            try
            {
                User user = GetUserById(userID);
                _user.DeleteUser(userID);
                return user;
            }
            catch (InvalidUserException)
            {
                throw new InvalidUserException();
            }
        }

    }
}
