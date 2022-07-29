using Services;
using DataAccess.Entities;
using DataAccess;
using WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<easypickingsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P2DB")));
/*
 *      DataAccess Layer scoping
*/
builder.Services.AddScoped<ITicket, TicketRepo>();
builder.Services.AddScoped<IPolicy, PolicyRepo>();
builder.Services.AddScoped<IClaimRepo, ClaimsRepo>();
builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
/*
 *      Service Layer Scoping    
*/
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<TicketService>();
//builder.Services.AddTransient<UserService>();
//builder.Services.AddTransient<ClaimsService>();
//builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<PolicyService>();
/*
 *      Controler Layer Scoping
*/
builder.Services.AddScoped<AuthController>();
//builder.Services.AddScoped<TicketController>();
//builder.Services.AddScoped<UserController>();
//builder.Services.AddScoped<PolicyController>();
//builder.Services.AddScoped<ClaimsController>();
//builder.Services.AddScoped<ContactController>();
app.MapGet("/", () => "Hello World!");
/*
 *      AuthController End Points
*/
app.MapPost("/login",(string? username, string? password, AuthController controller)=>controller.Login(username, password));
app.MapPost("/register", (User newUser, AuthController controller) => controller.Register(newUser));
/*
 *      UserController End Points
*/

/*
 *      TicketController End Points
 */

/*
 *      PolicyController End Points
 */

/*
 *      ClaimsController End Points
 */

/*
 *      ContactController End Points
 */

app.Run();
