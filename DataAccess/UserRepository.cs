using Models;
using CustomExceptions;
using Microsoft.Data.SqlClient;

namespace DataAccess;
public class UserRepository : IUserRepository
{
    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int userID)
    {
        throw new NotImplementedException();
    }

    public User GetUserByName(string userName)
    {
        throw new NotImplementedException();
    }

    public void ResetPassword(User user)
    {
        throw new NotImplementedException();
    }
}
