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
//builder.Services.AddScoped<IContact, ContactRepo>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
/*
 *      Service Layer Scoping    
*/
//builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<TicketService>();
//builder.Services.AddTransient<UserService>();
//builder.Services.AddTransient<ClaimsService>();
//builder.Services.AddTransient<ContactService>();
builder.Services.AddTransient<PolicyService>();
/*
 *      Controler Layer Scoping
*/
//builder.Services.AddScoped<AuthController>();
//builder.Services.AddScoped<TicketController>();
//builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<PolicyController>();
//builder.Services.AddScoped<ClaimsController>();
//builder.Services.AddScoped<ContactController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/policy", (PolicyController controller) =>controller.GetAllPolicy());
app.MapGet("/policy/ID/{ID}", (int policyID, PolicyController controller) => controller.GetPolicyByID(policyID));
app.MapGet("/policy/insurance/{insurance}", (int insurance, PolicyController controller) => controller.GetPolicyByInsurance(insurance));
app.MapGet("/policy/coverage/{coverage}", (byte[] coverage, PolicyController controller) => controller.GetPolicyBycoverage(coverage));


app.Run();
