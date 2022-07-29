
using CustomExceptions;
using Microsoft.Data.SqlClient;
using DataAccess.Entities;

namespace DataAccess;
public class UserRepo : IUserRepo
{
    private readonly easypickingsContext _context;

    public UserRepo(easypickingsContext context)
    {
        _context = context;
    }

    public User CreateUser(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }


    public User GetUserById(int userID)
    {
        User? foundUser = _context.Users.FirstOrDefault(user => user.UserId == userID);
        if(foundUser != null) return foundUser;
        throw new NotImplementedException();
    }

    public User GetUserByName(string username)
    {
        User? foundUser = _context.Users.FirstOrDefault(user => user.Username == username);
        if (foundUser != null) return foundUser;
        throw new NotImplementedException();
    }
    //Should this be in auth service?
    public User ResetPassword(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user; 
        throw new NotImplementedException();
    }
}
