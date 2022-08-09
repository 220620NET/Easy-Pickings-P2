using Services;
using NewModels;
using CustomExceptions;
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
        catch (InputInvalidException)
        {
            return Results.BadRequest("There is no user with that username.");
        }
        catch (InvalidCredentialsException)
        {
            return Results.BadRequest("That password does not match that username");
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
        catch (DuplicateRecordException)
        {
            return Results.BadRequest("That user already exists in the system please either login or use a different username.");
        }
        catch (InputInvalidException)
        {
            return Results.BadRequest("The information that you submitted was improper and need to be corrected.");
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
        catch (InputInvalidException)
        {
            return Results.BadRequest("Please make sure to enter the required information properly.");
        }
    }
}