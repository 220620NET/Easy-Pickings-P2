using Services;
using DataAccess.Entities;
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
        List<User> users = _service.GetAllUsers();
        return users.Count > 0 ? Results.Ok(users) : Results.NoContent();
    }
    public IResult GetUserById(int userID)
    {
        return Results.Ok(_service.GetUserById(userID));
    }
    public IResult GetUserByName(string username)
    {
        return Results.Ok(_service.GetUserByName(username));
    }

}