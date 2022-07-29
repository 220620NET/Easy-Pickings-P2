using DataAccess;
using DataAccess.Entities;

namespace Services
{
    public class AuthService 
    {
        private readonly IUserRepo _userRep;
        public AuthService(IUserRepo user)
        {
            _userRep = user;
        }
        public User Login(string? username, string? password)
        {
            User user;
            try
            {
                username = username != null ? username : "";
                password = password != null ? password : "";
                user =_userRep.GetUserByName(username);
                if (user.Username == "")
                {
                    throw new NotImplementedException();
                }if(user.Password == password)
                {
                    return user;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }catch (NotImplementedException)
            {
                throw new NotImplementedException();
            }
        }
        public User Register(User newUser)
        {
            try
            {
                newUser.Username = newUser.Username != null ? newUser.Username : "";
                User test = _userRep.GetUserByName(newUser.Username);
                if (newUser.Username == test.Username)
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
        }
    }
}
