using Services;
using NewModels;
using DataAccess;
namespace WebAPI.Controllers;

public class AuthController
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    /// <summary>
    /// Will allow the API to login
    /// </summary>
    /// <remarks>Returns a Status Code 404 if the login was not successful</remarks>
    /// <param name="username">A valid username</param>
    /// <param name="password">A valid password</param>
    /// <returns>202 and the user</returns>
    public IResult Login(string? username, string? password)
    {
        try
        {
            return Results.Accepted("/login",_authService.Login(username, password));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest("Incorrect credentials");
        }
    }
    /// <summary>
    /// Will allow the API to register a new user
    /// </summary>
    /// <remarks>Returns a Status Code 404 if the registration was not successful</remarks>
    /// <param name="userToRegister">A valid user</param>
    /// <returns>202 and the user</returns>
    public IResult Register(User userToRegister)
    {
        try
        {
            return Results.Accepted("/register",_authService.Register(userToRegister));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
    /// <summary>
    /// Will allow the API to update a user
    /// </summary>
    /// <remarks>Returns a Stats Code 404 if the update was not successful</remarks>
    /// <param name="update">The user ID and the information to update</param>
    /// <returns>202 and the user</returns>
    public IResult ResetPassword(User update)
    {
        try
        {
            return Results.Accepted("/reset", _authService.ResetPassword(update));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
}