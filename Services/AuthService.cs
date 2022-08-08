using DataAccess;
using NewModels;

namespace Services
{
    public class AuthService
    {
        private readonly IUserRepo _userRep;
        public AuthService(IUserRepo user)
        {
            _userRep = user;
        }
        /// <summary>
        /// Will login in a user to the system
        /// </summary>
        /// <param name="username">A vaild username</param>
        /// <param name="password">A valid password</param>
        /// <returns>The user</returns>
        /// <exception cref="NotImplementedException">No user exists with that password or username</exception>
        public User Login(string? username, string? password)
        {
            User user;
            try
            {
                username = username != null ? username : "";
                password = password != null ? password : "";
                user = _userRep.GetUserByName(username, false);
                if (user.username == "")
                {
                    throw new NotImplementedException();
                }
                if (user.password == password)
                {
                    return user;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            catch (NotImplementedException)
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// This will register a new user
        /// </summary>
        /// <param name="newUser">A valid user object</param>
        /// <returns>The newly registered user</returns>
        /// <exception cref="NotImplementedException">That user already exists or was invalid</exception>
        public User Register(User newUser)
        {
            try
            {
                newUser.username = newUser.username != null ? newUser.username : "";
                User test = _userRep.GetUserByName(newUser.username,true);
                if (newUser.username == test.username ||newUser.password==null||newUser.first_name==null||newUser.last_name==null||newUser.role==null)
                {
                    throw new NotImplementedException();
                } 
                else
                {
                    return _userRep.CreateUser(newUser);
                }
            }
            catch (NotImplementedException)
            {
                throw new NotImplementedException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }
        /// <summary>
        /// Allows the user to update any information on their account
        /// </summary>
        /// <param name="update">The information for the user to update and their ID</param>
        /// <returns>The updated User</returns>
        /// <exception cref="NotImplementedException">That user could not be updated</exception>
        public User ResetPassword(User update)
        {
            try
            {
                return _userRep.ResetPassword(update);
            }
            catch (NotImplementedException)
            {
                throw new NotImplementedException();
            }
        }
    }
}