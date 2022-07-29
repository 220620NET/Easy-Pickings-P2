using Services;
using DataAccess.Entities;
using DataAccess;
using WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddScoped<TicketController>();
//builder.Services.AddScoped<UserController>();
//builder.Services.AddScoped<PolicyController>();
//builder.Services.AddScoped<ClaimsController>();
//builder.Services.AddScoped<ContactController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");

/*
 *      AuthController End Points
*/
app.MapPost("/login",(string? username, string? password, AuthController controller)=>controller.Login(username, password));
app.MapPost("/register", (User newUser, AuthController controller) => controller.Register(newUser));
app.MapPut("/reset", (User update, AuthController controller) => controller.ResetPassword(update));

/*
 *      UserController End Points
*/

/*
 *      TicketController End Points
 */
app.MapPost("/submit/ticket", (Ticket newTicket, TicketController controller) => controller.CreateTicket(newTicket));
app.MapPut("/update/ticket", (Ticket ticket, TicketController controller) => controller.UpdateTicket(ticket));
app.MapDelete("/delete/ticket",(int ID,TicketController controller) => controller.DeleteTicket(ID));
app.MapGet("/ticket", (TicketController controller) => controller.GetAllTickets());
app.MapGet("/ticket/claim/{ID}", (int ID, TicketController controller)=>controller.GetTicketByClaim(ID));
app.MapGet("/ticket/patient/{ID}",(int ID,TicketController controller)=>controller.GetTicketByPatient(ID));


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
