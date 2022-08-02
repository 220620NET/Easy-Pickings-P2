using Services;
using NewModels;
using DataAccess;
using WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InsuranceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P2DB")));

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
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ClaimService>();
builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<PolicyService>();

/*
 *      Controler Layer Scoping
*/
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<TicketController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<PolicyController>();
builder.Services.AddScoped<ClaimController>();
builder.Services.AddScoped<ContactController>();


/*
 *      Setting up web app
 */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

/*
 *      AuthController End Points
*/
app.MapPost("/login", (string? username, string? password, AuthController controller) => controller.Login(username, password));
app.MapPost("/register", (User newUser, AuthController controller) => controller.Register(newUser));
app.MapPut("/reset", (User update, AuthController controller) => controller.ResetPassword(update));

/*
 *      UserController End Points
*/
app.MapGet("/user", (UserController controller) => controller.GetAllUsers());
app.MapGet("/user/ID/{userID}", (int userID, UserController controller) => controller.GetUserById(userID));
app.MapGet("/user/username/{username}", (string username, UserController controller) => controller.GetUserByName(username));
app.MapDelete("/user/delete", (int userID, UserController controller) => controller.DeleteUser(userID));


/*
 *      TicketController End Points
 */
app.MapPost("/submit/ticket", (Ticket newTicket, TicketController controller) => controller.CreateTicket(newTicket));
app.MapPut("/update/ticket", (Ticket ticket, TicketController controller) => controller.UpdateTicket(ticket));
app.MapDelete("/delete/ticket", (int ID, TicketController controller) => controller.DeleteTicket(ID));
app.MapGet("/ticket", (TicketController controller) => controller.GetAllTickets());
app.MapGet("/ticket/claim/{ID}", (int ID, TicketController controller) => controller.GetTicketByClaim(ID));
app.MapGet("/ticket/patient/{ID}", (int ID, TicketController controller) => controller.GetTicketByPatient(ID));

/*
 *      PolicyController End Points
 */
app.MapGet("/policy", (PolicyController controller) =>controller.GetAllPolicy());
app.MapGet("/policy/ID/{ID}", (int policyID, PolicyController controller) => controller.GetPolicyByID(policyID));
app.MapGet("/policy/insurance/{insurance}", (int insurance, PolicyController controller) => controller.GetPolicyByInsurance(insurance));
app.MapGet("/policy/coverage/{coverage}", (string coverage, PolicyController controller) => controller.GetPolicyBycoverage(coverage));
app.MapPost("/submit/policy", (NewModels.Policy newPolicy, PolicyController controller) => controller.CreatePolicy(newPolicy));
app.MapPut("/update/policy", (NewModels.Policy policy, PolicyController controller) => controller.UpdatePolicy(policy));
app.MapDelete("/delete/policy", (int ID, PolicyController controller) => controller.DeletePolicy(ID));

/*
 *      ClaimsController End Points
 */
        app.MapPost("/submit/Claim",(Claim newClaim, ClaimController controller) => controller.CreateClaims(newClaim));
        app.MapPut("/update/claim",(Claim claim, ClaimController controller) => controller.UpdateClaims(claim));
        app.MapDelete("/delete/claim", (int ID, ClaimController controller) => controller.DeleteClaims(ID));
        app.MapGet("/claims", (ClaimController controller) => controller.GetAllClaims());
        app.MapGet("/claim{ID}",(int Id, ClaimController controller ) => controller.GetClaimById(Id));
        app.MapGet("/claim/patient{ID}",(int Id, ClaimController controller) => controller.GetUserByPatientId(Id));
        
/*
 *      ContactController End Points
 */

app.Run();
