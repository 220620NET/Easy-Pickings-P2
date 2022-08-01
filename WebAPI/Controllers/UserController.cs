using Services;
using NewModels;
using DataAccess;


namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }
    public IResult GetAllUsers()
    {
        try
        {
            return Results.Accepted("/user", _service.GetAllUsers());
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    public IResult GetUserById(int userID)
    {
        try
        {
            return Results.Accepted("/user/ID/{userID}", _service.GetUserById(userID));
        }
        catch (NotImplementedException)
        { 
            return Results.BadRequest();
        }
    }
    public IResult GetUserByName(string username)
    {
        try
        {
            return Results.Accepted("/user/username/{username}", _service.GetUserByName(username));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    public IResult DeleteUser(int userID)
    {
        try
        {
            return Results.Accepted("/user/delete", _service.DeleteUser(userID));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }


}