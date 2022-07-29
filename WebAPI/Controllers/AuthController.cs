using Services;
using DataAccess.Entities;
using DataAccess;
namespace WebAPI.Controllers;

public class AuthController
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    public IResult Login(string? username, string? password)
    {
        try
        {
            return Results.Accepted("/login",_authService.Login(username, password));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
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