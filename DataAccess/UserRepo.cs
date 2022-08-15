using Microsoft.EntityFrameworkCore;
using CustomExceptions;
using Microsoft.Data.SqlClient;
using NewModels;

namespace DataAccess;
public class UserRepo : IUserRepo
{

    private readonly InsuranceDbContext _context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public UserRepo(InsuranceDbContext context)

 
    {
        _context = context;
    }
    /// <summary>
    /// Will add a user to the database
    /// </summary>
    /// <param name="newUser">A valid user</param>
    /// <returns>The new user</returns>
    public User CreateUser(User newUser)
    {
        _context.Users.Add(newUser);
        Finish();
        return newUser;
    }
    /// <summary>
    /// Will read all users in the database
    /// </summary>
    /// <returns>Users in the database</returns>
    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    /// <summary>
    /// Will get a specific user
    /// </summary>
    /// <param name="userID">The user in question</param>
    /// <returns>The requested user</returns>
    /// <exception cref="NotImplementedException">There is no user with that ID</exception>
    public User GetUserById(int userID)
    {
        User? foundUser = _context.Users.AsNoTracking().FirstOrDefault(user => user.userID == userID);
        if(foundUser != null) return foundUser;
        throw new NotImplementedException();
    }
    /// <summary>
    /// Will get a specfic user and will allow for registration
    /// </summary>
    /// <param name="username">A valid username</param>
    /// <param name="registering">True if registering false other wise</param>
    /// <returns>The requested user</returns>
    /// <exception cref="NotImplementedException">There is no user with that username</exception>
    public User GetUserByName(string username, bool registering)
    {
        try
        {
             return _context.Users.AsNoTracking().FirstOrDefault(user => user.username == username)!;
           
        }
        catch (NullReferenceException)
        {
            throw new InputInvalidException();
        }
        catch (DuplicateRecordException)
        {
            throw new DuplicateRecordException();
        }
        
    }

    /// <summary>
    /// Will allow the user to update information
    /// </summary>
    /// <param name="user">The userID and the information to update</param>
    /// <returns>The updated user</returns>
    /// <exception cref="NotImplementedException">That user could not be updated</exception>

    public User ResetPassword(User user)
    {
            _context.Users.Update(user);
            Finish();
            return user;
        
    }
    public bool DeleteUser(int userID)
    {
        User? ticketToDelete = _context.Users.FirstOrDefault(ticket => ticket.userID == userID);
        if (ticketToDelete != null)
        {
            _context.Entry(ticketToDelete).State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }
        return false;
    }
    protected void Finish()
    {
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
}
