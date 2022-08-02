﻿
using CustomExceptions;
using Microsoft.Data.SqlClient;
using NewModels;

namespace DataAccess;
public class UserRepo : IUserRepo
{
    private readonly InsuranceDbContext _dbContext;

    public UserRepo(InsuranceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <summary>
    /// Will add a user to the database
    /// </summary>
    /// <param name="newUser">A valid user</param>
    /// <returns>The new user</returns>
    public User CreateUser(User newUser)
    {
        _dbContext.users.Add(newUser);
        _dbContext.SaveChanges();
        return newUser;
    }
    /// <summary>
    /// Will read all users in the database
    /// </summary>
    /// <returns>Users in the database</returns>
    public List<User> GetAllUsers()
    {
        return _dbContext.users.ToList();
    }

    /// <summary>
    /// Will get a specific user
    /// </summary>
    /// <param name="userID">The user in question</param>
    /// <returns>The requested user</returns>
    /// <exception cref="NotImplementedException">There is no user with that ID</exception>
    public User GetUserById(int userID)
    {
        User? foundUser = _dbContext.users.FirstOrDefault(user => user.userID == userID);
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
        User? foundUser = _dbContext.users.FirstOrDefault(user => user.username == username);
        if (registering)
        {
            if (foundUser == null) return new User();
        }
        else
        {
            if (foundUser != null) return foundUser;
        }
        throw new NotImplementedException();
    }

    /// <summary>
    /// Will allow the user to update information
    /// </summary>
    /// <param name="user">The userID and the information to update</param>
    /// <returns>The updated user</returns>
    /// <exception cref="NotImplementedException">That user could not be updated</exception>

    public User ResetPassword(User user)
    {
        _dbContext.users.Update(user);
        _dbContext.SaveChanges();
        return user; 
        throw new NotImplementedException();
    }
    public User DeleteUser(int userID)
    {
        User? userToDelete = _dbContext.users.FirstOrDefault(user => user.userID == userID);
        if (userToDelete != null)
        {
            _dbContext.users.Remove(userToDelete);
        }
        else
        {
            throw new Exception();
        }
        _dbContext.SaveChanges();
        return userToDelete ?? throw new NotImplementedException();
    }
}
